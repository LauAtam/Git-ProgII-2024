using System.Diagnostics;
using U1___Problema_5.Datos.Repositorios;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Servicios
{
    public class FacturaManager
    {
        private FacturaRepository _facturaRepository = new FacturaRepository();
        private FormaPagoManager _formaPagoManager = new FormaPagoManager();
        private ArticuloManager _articuloManager = new ArticuloManager();
        public bool GuardarFactura()
        {
            Factura factura = new Factura();
            Console.Write("Nombre del cliente: ");
            factura.NombreCliente = Console.ReadLine();
            factura.FormaPago = _formaPagoManager.SeleccionarFormaPago();

            bool agregarDetalle = true;
            while (agregarDetalle)
            {
                DetalleFactura detalle = new DetalleFactura();
                detalle.Articulo = _articuloManager.SeleccionarArticulo();
                Console.Write("Ingrese la cantidad del articulo: ");
                detalle.Cantidad = int.Parse(Console.ReadLine());
                factura.Detalles.Add(detalle);

                Console.WriteLine("Agregar otro detalle? y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "n" || input == "no")
                    agregarDetalle = false;
            }
            return _facturaRepository.Guardar(factura);
        }
        public bool EliminarFacturaYDetalles(Factura factura)
        {
            return _facturaRepository.Eliminar(factura);
        }

        public List<Factura> ObtenerFacturas()
        {
            return _facturaRepository.ObtenerTodos();
        }
    }
}
