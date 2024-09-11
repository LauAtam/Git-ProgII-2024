﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using U1___Problema_5.Properties;

namespace U1___Problema_5.Datos
{
    public class DBHelper
    {
        private static DBHelper _instancia = null;
        private SqlConnection _conexion;

        private DBHelper()
        {
            _conexion = new SqlConnection(Resources.cadenaDeConexion);
        }

        public static DBHelper ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new DBHelper();
            }
            return _instancia;
        }

        /// <summary>
        /// Metodo para ejecutar un Stored Procedure que retorne una tabla
        /// </summary>
        /// <param name="spName">Nombre del stored procedure</param>
        /// <param name="parametros">Lista de SqlParameter que representa los parametros del SP</param>
        /// <returns>DataTable</returns>
        public DataTable? EjecutarSP(string spName, List<SqlParameter>? parametros = null)
        {
            DataTable? datatable = new DataTable();
            SqlCommand cmd = new SqlCommand(spName, _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            //using (_conexion)
            //{
            try
            {
                _conexion.Open();
                datatable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando SP \"{spName}\" en: DBHelper.EjecutarSP.\nMensaje de error: {ex.Message}");
                datatable = null;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            //}
            return datatable;
        }

        /// <summary>
        /// Metodo para ejecutar consultas de tipo Data Modification Language
        /// </summary>
        /// <param name="spName">Nombre del stored procedure</param>
        /// <param name="parametros">Lista de SqlParameter que representa los parametros del SP</param>
        /// <returns>Numero de registros (filas) afectados</returns>
        public int EjecutarSPDML(string spName, List<SqlParameter>? parametros = null)
        {
            int filas;
            SqlCommand cmd = new SqlCommand(spName, _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            //using (_conexion)
            //{
            _conexion.Open();
            SqlTransaction transaccion = _conexion.BeginTransaction();
            try
            {
                cmd.Transaction = transaccion;
                filas = cmd.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando SP \"{spName}\" en: DBHelper.EjecutarSPDML.\nMensaje de error: {ex.Message}");
                filas = 0;
                try
                {
                    transaccion.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine(exRollback.Message);
                }
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
                //}
            }
            return filas;
        }

        public bool ConsultaSPDMLMaestroDetalle(string spMaestro, string spDetalle, List<SqlParameter>? paramsMaestro = null, List<List<SqlParameter>>? paramsDetalles = null)
        {
            bool resultado = false;
            /*using (_conexion)
            {*/
            _conexion.Open();
            /*using (SqlTransaction transaccion = _conexion.BeginTransaction())
            {*/
            SqlTransaction transaccion = _conexion.BeginTransaction();
            try
            {
                //Ejecutar el SP del maestro que retorna el ultimo ID
                int idMaestro = EjecutarSPDMLMaestro(_conexion, transaccion, spMaestro, paramsMaestro);
                //Ejecutar el SP del detalle por cada detalle
                EjecutarSPDMLDetalles(_conexion, transaccion, idMaestro, spDetalle, paramsDetalles);
                transaccion.Commit();
                resultado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaccion.Rollback();
                }
                catch (Exception exTransaccion)
                {
                    Console.WriteLine($"Error en el rollback de la transaccion.\n{exTransaccion.Message}");
                }
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            //}
            //}
            return resultado;
        }

        private int EjecutarSPDMLMaestro(SqlConnection conexion, SqlTransaction transaccion, string spMaestro, List<SqlParameter>? paramsMaestro)
        {
            /*using (SqlCommand cmdMaestro = new SqlCommand(spMaestro, conexion, transaccion))
            {*/
            SqlCommand cmdMaestro = new SqlCommand(spMaestro, conexion, transaccion);
            cmdMaestro.CommandType = CommandType.StoredProcedure;

            SqlParameter paramOutput = new SqlParameter("@id_maestro", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmdMaestro.Parameters.Add(paramOutput);

            if (paramsMaestro != null)
            {
                cmdMaestro.Parameters.AddRange(paramsMaestro.ToArray());
            }
            cmdMaestro.ExecuteNonQuery();

            if (paramOutput.Value == null)
            {
                throw new Exception("El SP del maestro no devolvió un Id valido");
            }
            return (int)paramOutput.Value;
            //}
        }

        private void EjecutarSPDMLDetalles(SqlConnection conexion, SqlTransaction transaccion, int idMaestro, string spDetalle, List<List<SqlParameter>>? paramsDetalles)
        {
            //using (SqlCommand cmdDetalle = new SqlCommand(spDetalle, conexion, transaccion))
            //{
            SqlCommand cmdDetalle = new SqlCommand(spDetalle, conexion, transaccion);
            cmdDetalle.CommandType = CommandType.StoredProcedure;
            if (paramsDetalles != null)
            {
                foreach (List<SqlParameter> detalle in paramsDetalles)
                {
                    cmdDetalle.Parameters.Clear();
                    cmdDetalle.Parameters.Add(new SqlParameter("@id_maestro", idMaestro));
                    cmdDetalle.Parameters.AddRange(detalle.ToArray());
                    cmdDetalle.ExecuteNonQuery();
                }
            }
            //}
        }
    }
}
