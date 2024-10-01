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
            string cabecera = string.Format(
                "{0, -20}{1, 20}\n" +
                "{2, -20}{3, 20}\n" +
                "{4, -20}{5, 20}\n" +
                "{6, -20}{7, 20}\n",
                "Factura Numero:", Id,
                "Fecha:", Fecha,
                "Forma de pago:", FormaPago.Nombre,
                "Cliente:", NombreCliente);
                //"----------------------------------------");
            string txtDetalles = "----------------DETALLE-----------------\n"; //40 de largo
            decimal total = 0;
            foreach (DetalleFactura detalle in Detalles)
            {
                /*txtDetalles += $"\n{detalle.NroDetalle} - {detalle.Articulo.Nombre}\t{detalle.Articulo.PrecioUnitario} x Un." +
                $"\n    {detalle.Cantidad}\t\t\t${detalle.Articulo.PrecioUnitario * detalle.Cantidad}";*/
                txtDetalles += string.Format(
                    "{0,-5}{1,-25}{2,10}\n" +
                    "     {3,-16}{4,19}\n",
                    $"{detalle.NroDetalle} - ", $"{detalle.Articulo.Nombre} x {detalle.Cantidad}", $"{detalle.Articulo.PrecioUnitario * detalle.Cantidad}",
                    "Precio unitario:", detalle.Articulo.PrecioUnitario);
                
                total += detalle.Cantidad * detalle.Articulo.PrecioUnitario;
            }
            /*string pie = $"\nTotal:\t{total}";*/
            string pie = string.Format(
                "----------------------------------------\n" +
                "{0, -6}{1, 34}\n" +
                "{2, -6}{3,34}",
                "Items:",Detalles.Count,
                "Total:",total
                );
            return cabecera + txtDetalles + pie;
        }
        /// <summary>
        /// Si existe un detalle con el producto seleccionado incrementa la cantidad, sino agrega un detalle nuevo a la lista de detalles
        /// </summary>
        /// <param name="detalle"></param>
        public void AgregarDetalle(DetalleFactura detalle)
        {
            int detalleExistente = Detalles.FindIndex(d => d.Articulo.Id == detalle.Articulo.Id);
            if (detalleExistente > -1)
            {
                Detalles[detalleExistente].Cantidad += detalle.Cantidad;
            }
            else
                Detalles.Add(detalle);
        }
    }
}
