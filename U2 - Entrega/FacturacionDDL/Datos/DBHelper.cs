using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FacturacionDDL.Properties;

namespace FacturacionDDL.Datos
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
        public DataTable EjecutarSP(string spName, List<SqlParameter> parametros = null)
        {
            DataTable datatable = new DataTable();
            SqlCommand cmd = new SqlCommand(spName, _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            try
            {
                _conexion.Open();
                datatable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando SP \"{spName}\".\nMensaje de error: {ex.Message}");
                datatable = null;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            return datatable;
        }
        public DataTable EjecutarSP(string spName, SqlParameter parametro = null)
        {
            DataTable datatable = new DataTable();
            SqlCommand cmd = new SqlCommand(spName, _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parametro != null)
            {
                cmd.Parameters.Add(parametro);
            }
            try
            {
                _conexion.Open();
                datatable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando SP \"{spName}\".\nMensaje de error: {ex.Message}");
                datatable = null;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            return datatable;
        }
        public DataTable EjecutarSP(string spName)
        {
            DataTable datatable = new DataTable();
            SqlCommand cmd = new SqlCommand(spName, _conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _conexion.Open();
                datatable.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ejecutando SP \"{spName}\".\nMensaje de error: {ex.Message}");
                datatable = null;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            return datatable;
        }

        /// <summary>
        /// Metodo para ejecutar consultas de tipo Data Modification Language
        /// </summary>
        /// <param name="spName">Nombre del stored procedure</param>
        /// <param name="parametros">Lista de SqlParameter que representa los parametros del SP</param>
        /// <returns>Numero de registros (filas) afectados</returns>
        public int EjecutarSPDML(string spName, List<SqlParameter> parametros = null)
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

        public bool ConsultaSPDMLMaestroDetalle(string spMaestro, string spDetalle, List<SqlParameter> paramsMaestro = null, List<List<SqlParameter>> paramsDetalles = null)
        {
            bool resultado = false;
            _conexion.Open();
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

        /// <summary>
        /// Metodo privado para la ejecucion de un query de tipo DML
        /// </summary>
        /// <param name="conexion">SqlConnection a la base de datos</param>
        /// <param name="transaccion">SqlTransaction de la SqlConnection</param>
        /// <param name="spMaestro">Stored Procedure del maestro</param>
        /// <param name="paramsMaestro">Parametros que recibe el Stored Procedure para trabajar</param>
        /// <returns>Id del maestro registrado</returns>
        /// <exception cref="Exception"></exception>
        private int EjecutarSPDMLMaestro(SqlConnection conexion, SqlTransaction transaccion, string spMaestro, List<SqlParameter> paramsMaestro)
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

        /// <summary>
        /// Metodo privado para la ejecucion de un query de tipo DML que inserte registros que tengan una fk a una tabla maestro
        /// </summary>
        /// <param name="conexion">SqlConnection a la base de datos</param>
        /// <param name="transaccion">SqlTransaction de la SqlConnection</param>
        /// <param name="spDetalle">Stored Procedure DML de la tabla de detalles</param>
        /// <param name="paramsDetalles">Parametros que recibe el Stored Procedure para trabajar</param>
        /// <param name="idMaestro">Id del maestro al que pertenecen los detalles</param>
        private void EjecutarSPDMLDetalles(SqlConnection conexion, SqlTransaction transaccion, int idMaestro, string spDetalle, List<List<SqlParameter>> paramsDetalles)
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
