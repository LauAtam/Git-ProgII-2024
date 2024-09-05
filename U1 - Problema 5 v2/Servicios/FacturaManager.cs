using System.Data.SqlClient;
using U1___Problema_5_v2.Datos.Repositories;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5_v2.Servicios
{
    public class FacturaManager
    {
        IRepository<Factura> _repository;
        public FacturaManager()
        {
            _repository = new FacturaRepository();
        }
        public List<Factura> GetFacturas()
        {
            throw new NotImplementedException();
        }
        public Factura GetFacturaById(int id)
        {
            throw new NotImplementedException();
        }
        public bool SaveFactura(Factura factura)
        {
            throw new NotImplementedException();
        }
        public bool DeleteFactura(int id)
        {
            throw new NotImplementedException();
        }
    }
}
