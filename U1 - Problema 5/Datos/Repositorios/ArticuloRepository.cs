using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Datos.Repositorios
{
    internal class ArticuloRepository : Repository<Articulo>
    {
        public override bool Eliminar(Articulo o)
        {
            throw new NotImplementedException();
        }

        public override bool Guardar(Articulo o)
        {
            throw new NotImplementedException();
        }

        public override Articulo ObtenerPorId(int id)
        {
            Articulo articulo = new Articulo();
            SqlParameter param = new SqlParameter("@id", id);
            DataTable? dtArticulo = _helper.EjecutarSP("SP_RECUPERAR_ARTICULOS_POR_ID", param);
            if (dtArticulo != null && dtArticulo.Rows.Count > 0)
            {
                articulo.Id = (int)dtArticulo.Rows[0]["id"];
                articulo.Nombre = (string)dtArticulo.Rows[0]["nombre"];
                //object precioUnitario = dtArticulo.Rows[0]["precio_unitario"];
                articulo.PrecioUnitario = (decimal)dtArticulo.Rows[0]["precio_unitario"];
            }
            return articulo;
        }

        public override List<Articulo> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
