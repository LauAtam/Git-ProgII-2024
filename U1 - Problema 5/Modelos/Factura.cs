using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string NombreCliente { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }
        public override string ToString()
        {
            string cabecera =
                $"Factura Numero: {Id}\n" +
                $"Fecha: {Fecha}\n" +
                $"Pagado con {FormaPago.Nombre}\n" +
                $"Cliente: {NombreCliente}\n" +
                $"-------------------------------------------------------\n";
            string txtDetalles = "DETALLES:\n";
            decimal total = 0;
            foreach (DetalleFactura detalle in Detalles)
            {
                txtDetalles += $"\n{detalle.NroDetalle} - {detalle.Articulo.Nombre}\t{detalle.Articulo.PrecioUnitario} x Un." +
                    $"\n    {detalle.Cantidad}\t\t\t${detalle.Articulo.PrecioUnitario * detalle.Cantidad}";
                total += detalle.Cantidad * detalle.Articulo.PrecioUnitario;
            }
            string pie = $"\nTotal:\t{total}";
            return cabecera + txtDetalles + pie;
        }
    }
}
