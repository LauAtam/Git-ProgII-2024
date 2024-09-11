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
        public bool GuardarFactura(Factura factura)
        {
            return _facturaRepository.Guardar(factura);
        }
    }
}
