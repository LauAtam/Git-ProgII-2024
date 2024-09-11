using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using U1___Problema_5.Properties;

namespace U1___Problema_5.Datos
{
    public class DBHelper
    {
        private DBHelper _instancia = null;
        private SqlConnection _conexion;

        private DBHelper()
        {
            _conexion = new SqlConnection(Resources.cadenaDeConexion);
        }

        public DBHelper ObtenerInstancia()
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
            using (_conexion)
            {
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
            }
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
            using (_conexion)
            {
                try
                {
                    _conexion.Open();
                    filas = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error ejecutando SP \"{spName}\" en: DBHelper.EjecutarSPDML.\nMensaje de error: {ex.Message}");
                    filas = 0;
                }
                finally
                {
                    if (_conexion.State == ConnectionState.Open)
                    {
                        _conexion.Close();
                    }
                }
            }
            return filas;
        }

        public bool EjecutarSPDMLMaestroDetalles(string spMaestro, string spDetalle, List<SqlParameter>? paramsMaestro = null, List<List<SqlParameter>>? paramsDetalles = null)
        {
            bool resultado = false;
            int idMaestro = 0;
            _conexion.Open();
            SqlTransaction transaccion = _conexion.BeginTransaction();
            SqlCommand cmdMaestro = new SqlCommand()
            {
                CommandText = spMaestro,
                Connection = _conexion,
                Transaction = transaccion,
                CommandType = CommandType.StoredProcedure,       
            };
            SqlParameter paramOutput = new SqlParameter() { ParameterName = "@id_factura", Direction = ParameterDirection.Output};
            cmdMaestro.Parameters.Add(paramOutput);
            if (paramsMaestro != null)
            {
                cmdMaestro.Parameters.AddRange(paramsMaestro.ToArray());
            }
            List<SqlCommand> cmdDetalles = new List<SqlCommand>();
                /*CommandText = spDetalle,
                Connection = _conexion,
                Transaction = transaccion,
                CommandType = CommandType.StoredProcedure,*/
            try
            {
                cmdMaestro.ExecuteNonQuery();
                idMaestro = (int)(paramOutput.Value);

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error ejecutando SP \"{spName}\" en: DBHelper.EjecutarSPDMLMaestroDetalle.\nMensaje de error: {ex.Message}");
                throw;
            }
            return resultado;
        }
    }
}
