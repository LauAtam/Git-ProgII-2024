using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5_v2.Properties;

namespace U1___Problema_5_v2.Datos
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
        /// Metodo para ejecutar consultas en la base de datos mediante
        /// stored procedures con una lista de ParametroSQL
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parametros"></param>
        /// <returns>Tabla resultante de la consulta</returns>
        public DataTable? EjecutarSP(string spName, List<ParametroSQL>? parametros = null)
        {
            DataTable table = new DataTable();
            SqlCommand comandoSql = new SqlCommand(spName, _conexion);
            comandoSql.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                foreach (ParametroSQL parametro in parametros)
                {
                    comandoSql.Parameters.Add(new SqlParameter(parametro.Nombre, parametro.Valor));
                }
            }
            try
            {
                using (_conexion)
                {
                    _conexion.Open();
                    table.Load(comandoSql.ExecuteReader());
                }
            }
            catch (SqlException)
            {
                table = null;
            }
            finally
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            return table;
        }
        /// <summary>
        /// Metodo para ejecutar consultas de tipo Data Modification Language
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parametros"></param>
        /// <returns>Cantidad de filas afectadas</returns>
        public int EjecutarSPDML(string spName, List<ParametroSQL>? parametros = null)
        {
            int filas = 0;
            SqlCommand comando = new SqlCommand(spName, _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                foreach (ParametroSQL parametro in parametros)
                {
                    comando.Parameters.Add(new SqlParameter(parametro.Nombre, parametro.Valor));
                }
            }
            try
            {
                _conexion.Open();
                filas = comando.ExecuteNonQuery();
                _conexion.Close();
            }
            catch (SqlException)
            {
                filas = 0;
            }
            return filas;
        }
    }
}
