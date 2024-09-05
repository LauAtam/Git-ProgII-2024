using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace U1___Problema_5_v2.Datos.Repositories
{
    abstract class Repository<TObject> : IRepository<TObject>
    {
        protected DBHelper _helper;
        protected List<ParametroSQL> _parametros;
        public Repository()
        {
            _helper = DBHelper.ObtenerInstancia();
        }
        public abstract bool Delete(int id);
        public abstract List<TObject> GetAll();
        public abstract TObject GetByID(int id);
        public abstract bool Save(TObject o);
    }
}
