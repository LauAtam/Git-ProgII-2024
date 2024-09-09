using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class Factura
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int idFormaPago { get; set; }
        public string nombreCliente { get; set; }
        public List<DetalleFactura> detalleFacturas { get; set; }
        public Factura()
        {
            
        }
        public Factura(int id, DateTime fecha, int idFormaPago, string nombreCliente)
        {
            this.id  = id;
            this.fecha = fecha;
            this.idFormaPago = idFormaPago;
            this.nombreCliente = nombreCliente;
        }
        public override string ToString()
        {
            return $"{id}\t-{fecha}\t-{idFormaPago}\t-{nombreCliente}-";
        }
        public void AgregarDetalle(DetalleFactura detalle)
        {
            throw new NotImplementedException();
        }
    }
}
