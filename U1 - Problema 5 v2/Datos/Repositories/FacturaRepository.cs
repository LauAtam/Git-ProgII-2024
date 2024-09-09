using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5_v2.Datos.Repositories
{
    internal class FacturaRepository : Repository<Factura>
    {
        public FacturaRepository() : base() { }
        public override bool Delete(int id)
        {
            _spName = "SP_ELIMINAR_FACTURA";
            int lineas = 0;
            _parametros.Add(new ParametroSQL("@id", id));
            lineas = _helper.EjecutarSPDML(_spName, _parametros);
            return lineas == 1;
        }

        public override List<Factura> GetAll()
        {
            _spName = "SP_RECUPERAR_FACTURAS";
            DataTable table = _helper.EjecutarSP(_spName);
            List<Factura> facturas = new List<Factura>();
            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                int idFormaPago = Convert.ToInt32(row["id_forma_pago"]);
                string nombreCliente = Convert.ToString(row["nombre_cliente"]);
                Factura factura = new Factura(id, fecha, idFormaPago, nombreCliente);
                facturas.Add(factura);
            }
            _parametros.Clear();
            return facturas;
        }

        public override Factura GetByID(int id)
        {
            _spName = "SP_RECUPERAR_FACTURA_POR_ID";
            _parametros.Add(new ParametroSQL("@id", id));
            DataTable table = new DataTable();
            table = _helper.EjecutarSP(_spName, _parametros);
            _parametros.Clear();
            if (table != null && table.Rows.Count == 1)
            {
                DataRow row = table.Rows[0];
                Factura factura = new Factura();
                factura.id = Convert.ToInt32(row["ID"]);
                factura.fecha = Convert.ToDateTime(row["fecha"]);
                factura.idFormaPago = Convert.ToInt32(row["id_forma_pago"]);
                factura.nombreCliente = Convert.ToString(row["nombre_cliente"]);
                return factura;
            }
            return null;
        }

        public override bool Save(Factura o)
        {
            _spName = "SP_GUARDAR_FACTURA";
            _parametros.Add(new ParametroSQL("@fecha", o.fecha));
            _parametros.Add(new ParametroSQL("@id_forma_pago", o.idFormaPago));
            _parametros.Add(new ParametroSQL("@nombre_cliente", o.nombreCliente));
            int rows = _helper.EjecutarSPDML(_spName, _parametros);
            _parametros.Clear();
            return rows == 1;

        }
    }
}
