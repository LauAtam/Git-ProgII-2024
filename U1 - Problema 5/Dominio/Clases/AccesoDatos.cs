using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5.Dominio.Interfaces;

namespace U1___Problema_5.Dominio.Clases
{
    public class AccesoDatos
    {
        private static AccesoDatos _acceso;
        static SqlConnection conexion;
        SqlCommand cmd;
        
        private AccesoDatos()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);
            cmd = new SqlCommand();
            cmd.Connection = conexion;
        }

        public static AccesoDatos ObtenerInstancia()
        {
            if (_acceso == null)
            {
                _acceso = new AccesoDatos();
            }
            return _acceso;
        }

        public static DataTable Consultar(string sp)
        {
            DataTable dt = new DataTable();
            conexion.Open();
            AccesoDatos a = ObtenerInstancia();
            a.cmd.CommandText = sp;
            a.cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(a.cmd.ExecuteReader());
            conexion.Close();
            return dt;
        }
        public static bool EjecutarSp(string sp, int id)
        {
            bool aux = false;
            conexion.Open();
            AccesoDatos a = ObtenerInstancia();
            a.cmd.Parameters.AddWithValue("@id", id);
            a.cmd.CommandText = sp;
            a.cmd.CommandType = CommandType.StoredProcedure;
            return a.cmd.ExecuteNonQuery() >0;
            conexion.Close();
        }
    }
}
