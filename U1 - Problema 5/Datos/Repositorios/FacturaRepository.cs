using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5.Datos.Repositorios
{
    public class FacturaRepository : Repository<Factura>
    {
        public FacturaRepository() : base()
        {

        }
        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Guardar(Factura factura)
        {
            int contadorDetalles = 0;
            string spMaestro = "SP_GUARDAR_FACTURA";
            string spDetalle = "SP_GUARDAR_DETALLE_FACTURA";
            List<SqlParameter> maestro = new List<SqlParameter>()
            {
                new SqlParameter("@id", factura.Id),
                new SqlParameter("@id_forma_pago", factura.FormaPago.Id),
                new SqlParameter("@nombre_cliente", factura.NombreCliente),
            };
            List<List<SqlParameter>> detalles = new List<List<SqlParameter>>();
            foreach (DetalleFactura detalle in factura.Detalles)
            {
                contadorDetalles++;
                detalles.Add(new List<SqlParameter>()
                {
                    new SqlParameter("@id", detalle.Id),
                    new SqlParameter("@nro_detalle", contadorDetalles),
                    new SqlParameter("@id_articulo", detalle.Articulo.Id),
                    new SqlParameter("@cantidad", detalle.Cantidad)
                });
            }
            return _helper.ConsultaSPDMLMaestroDetalle(spMaestro, spDetalle, maestro, detalles);
        }

        public override Factura ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Factura> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
