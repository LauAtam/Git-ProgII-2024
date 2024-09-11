using U1___Problema_5.Servicios;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FacturaManager facturaManager = new FacturaManager();
            #region Articulos de ejemplo - TODO obtenerlos de la DB
            Articulo lapicera = new Articulo() { Id = 1, Nombre = "Lapicera", PrecioUnitario = 200.00f };
            Articulo goma = new Articulo() { Id = 2, Nombre = "Goma", PrecioUnitario = 50.00f };
            Articulo pañuelitosDescartables = new Articulo() { Id = 3, Nombre = "Pañuelitos Descartables", PrecioUnitario = 500.50f };
            Articulo mantecaDeCacao = new Articulo() { Id = 4, Nombre = "Manteca de cacao", PrecioUnitario = 3600.00f };
            #endregion

            #region Formas de pago - TODO obtenerlos de la DB
            FormaPago efectivo = new FormaPago() { Id = 1, Nombre = "Efectivo" };
            FormaPago debito = new FormaPago() { Id = 2, Nombre = "Debito" };
            FormaPago credito = new FormaPago() { Id = 3, Nombre = "Credito" };
            #endregion

            #region Crear Factura
            Factura factura1 = new Factura()
            {
                FormaPago = efectivo,
                NombreCliente = "Lautaro Atampiz",
                Detalles = new List<DetalleFactura>()
                {
                    new DetalleFactura() { Articulo = lapicera, Cantidad = 1 },
                    new DetalleFactura() { Articulo = goma, Cantidad = 1 },
                    new DetalleFactura() { Articulo = pañuelitosDescartables, Cantidad = 1 }
                }
            };
            /*factura1.Detalles.Add(new DetalleFactura() { Articulo = lapicera, Cantidad = 1 });
            factura1.Detalles.Add(new DetalleFactura() { Articulo = goma, Cantidad = 1 });
            factura1.Detalles.Add(new DetalleFactura() { Articulo = pañuelitosDescartables, Cantidad = 1 });*/
            #endregion

            string mensaje = facturaManager.GuardarFactura(factura1) ? "Insercion exitosa" : "Ha ocurrido un error";
            Console.WriteLine(mensaje);
        }
    }
}