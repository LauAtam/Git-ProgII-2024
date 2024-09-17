using System;
using System.Collections.Generic;
using FacturacionDDL.Datos.Repositorios;
using FacturacionDDL.Modelos;

namespace FacturacionDDL.Servicios
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
                factura.AgregarDetalle(detalle);
                Console.WriteLine("Agregar otro detalle? y/n");
                string input = Console.ReadLine().ToLower();
                if (input == "n" || input == "no")
                    agregarDetalle = false;
            }
            return _facturaRepository.Guardar(factura);
        }

        public void ObtenerFacturas()
        {
            List<Factura> facturas = _facturaRepository.ObtenerTodos();
            foreach (Factura f in facturas)
            {
                Console.WriteLine("########################################");
                Console.WriteLine(f.ToString());
            }
        }

        internal void EliminarFactura()
        {
            List<Factura> facturas = _facturaRepository.ObtenerTodos();
            foreach (Factura f in facturas)
            {
                Console.WriteLine($"{f.Id} - {f.NombreCliente} - {f.Fecha}");
            }
            Console.Write($"\n----------------------------------------\n" +
                $"Seleccione la factura a eliminar: ");
            var input = Console.ReadLine();
            int index;
            int.TryParse(input, out index);
            var factura = facturas.Find(f => f.Id == index);
            if (factura != null && facturas.Exists(f => f.Equals(factura)))
            {
                if (_facturaRepository.Eliminar(factura))
                {
                    Console.WriteLine($"Factura {factura.Id} eliminada exitosamente");
                }
                else
                {
                    Console.WriteLine($"No es pudo eliminar la factura {factura.Id}");
                }
            }
            else
            {
                Console.WriteLine($"La factura con id {index} no existe");
            }
            Console.WriteLine("----------------------------------------\n");
        }
    }
}
