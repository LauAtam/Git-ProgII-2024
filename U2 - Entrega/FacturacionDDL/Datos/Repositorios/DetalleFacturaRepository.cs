using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FacturacionDDL.Modelos;

namespace FacturacionDDL.Datos.Repositorios
{
    public class DetalleFacturaRepository : Repository<DetalleFactura>
    {
        private IRepository<Articulo> articuloRepository = new ArticuloRepository();
        public override bool Eliminar(DetalleFactura o)
        {
            throw new NotImplementedException();
        }

        public override bool Guardar(DetalleFactura o)
        {
            throw new NotImplementedException();
        }

        public override DetalleFactura ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
        public List<DetalleFactura> ObtenerPorIdMaestro(int id)
        {
            DataTable dtDetalles = new DataTable();
            List<DetalleFactura> lstDetalles = new List<DetalleFactura>();
            SqlParameter param = new SqlParameter("@id", id);
            dtDetalles = _helper.EjecutarSP("SP_RECUPERAR_DETALLES_FACTURAS_POR_ID_FACTURA", param);
            if (dtDetalles != null && dtDetalles.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetalles.Rows)
                {
                    lstDetalles.Add(new DetalleFactura()
                    {
                        Id = (int)row ["id"],
                        NroDetalle = (int)row ["nro_detalle"],
                        Cantidad = (int)row["cantidad"],
                        Articulo = articuloRepository.ObtenerPorId((int)row["id_articulo"]),
                    });
                } 
            }
            return lstDetalles;
        }

        public override List<DetalleFactura> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
