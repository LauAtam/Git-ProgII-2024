using U1___Problema_5.Datos.Repositorios;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Servicios
{
    public class FacturaManager
    {
        private FacturaRepository _facturaRepository;
        public FacturaManager()
        {
            _facturaRepository = new FacturaRepository();
        }
        public bool GuardarFactura(Factura factura)
        {
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
