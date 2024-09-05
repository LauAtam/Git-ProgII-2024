using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5_v2.Dominio;

namespace U1___Problema_5_v2.Datos.Repositories
{
    internal class ArticuloRepository : Repository<Articulo>
    {
        public ArticuloRepository(): base()
        {

        }
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Articulo> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Articulo GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Articulo articulo)
        {
            List<ParametroSQL> parametros = new List<ParametroSQL>();
            parametros.Add(new ParametroSQL("nombre",articulo.Nombre));
            parametros.Add(new ParametroSQL("precio", articulo.PrecioUnitario));
            return _helper.EjecutarSPDML("sp_crear_articulo", parametros) > 0;
        }
    }
}
