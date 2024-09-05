using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5_v2.Datos.Repositories
{
    internal class FacturaRepository : Repository<Factura>
    { 
        public FacturaRepository() : base()
        {
            
        }
        public override bool Delete(int id)
        {
            string spName = "SP_ELIMINAR_FACTURA";
            int lineas = 0;
            _parametros.Add(new ParametroSQL("@id", id));
            lineas = _helper.EjecutarSPDML(spName, _parametros);
            return lineas == 1;
        }

        public override List<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Factura GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Factura o)
        {
            throw new NotImplementedException();
        }
    }
}
