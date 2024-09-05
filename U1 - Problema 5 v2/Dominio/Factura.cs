using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class Factura
    {
        public int id { get; private set; }
        public DateTime fecha { get; private set; }
        public int idFormaPago { get; private set; }
        public string nombreCliente { get; private set; }
        public List<DetalleFactura> detalles { get; private set; }
        public Factura(int id, DateTime fecha, int idFormaPago, string nombreCliente, List<DetalleFactura> detalles)
        {
            this.id  = id;
            this.fecha = fecha;
            this.idFormaPago = idFormaPago;
            this.nombreCliente = nombreCliente;
            this.detalles = detalles;
        }
    }
}
