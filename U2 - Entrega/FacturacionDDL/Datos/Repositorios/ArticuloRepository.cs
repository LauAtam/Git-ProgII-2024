using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FacturacionDDL.Modelos;

namespace FacturacionDDL.Datos.Repositorios
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
            DataTable dtArticulo = _helper.EjecutarSP("SP_RECUPERAR_ARTICULOS_POR_ID", param);
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
            DataTable dtArticulos = _helper.EjecutarSP("SP_RECUPERAR_ARTICULOS");
            List<Articulo> lstArticulos = new List<Articulo>();
            if (dtArticulos != null && dtArticulos.Rows.Count > 0)
            {
                foreach (DataRow row in dtArticulos.Rows)
                {
                    lstArticulos.Add(new Articulo() { Id = (int)row["id"], Nombre = (string)row["nombre"], PrecioUnitario = (decimal)row["precio_unitario"] });
                }
            }
            return lstArticulos;
        }
    }
}
