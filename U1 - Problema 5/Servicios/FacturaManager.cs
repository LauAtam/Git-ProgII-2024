using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5.Datos.Repositorios;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5.Servicios
{
    public class FacturaManager
    {
        private FacturaRepository _facturaRepository;
        public FacturaManager()
        {
            _facturaRepository = new FacturaRepository();
        }
        public bool GuardarFactura()
        {
            string input;
            Factura factura = new Factura()
            {
                Detalles = new List<DetalleFactura>()
            };
            Console.Write("Nombre del cliente: ");
            factura.NombreCliente = Console.ReadLine();
            //Console.Write("Forma de pago: ");
            factura.FormaPago = new FormaPago() { Id=1, Nombre="Efectivo"};
            bool agregarDetalle = true;
            while (agregarDetalle)
            {
                DetalleFactura detalle = new DetalleFactura();
                Console.Write("Ingrese el articulo: ");
                detalle.Articulo = new Articulo() { Id = 1 };

                Console.Write("Ingrese la cantidad del articulo: ");
                detalle.Cantidad = int.Parse(Console.ReadLine());

                factura.Detalles.Add(detalle);
                Console.WriteLine("Agregar otro detalle? y/n");
                input = Console.ReadLine().ToLower();
                agregarDetalle = input == "y" ? true : false;
            }
            return _facturaRepository.Guardar(factura);
        }
        public bool EliminarFacturaYDetalles(Factura factura)
        {
            return _facturaRepository.Eliminar(factura);
        }

        public List<Factura> ObtenerFacturas(int n)
        {
            return (List<Factura>)_facturaRepository.ObtenerTodos().Take(n);
        }
    }
}
