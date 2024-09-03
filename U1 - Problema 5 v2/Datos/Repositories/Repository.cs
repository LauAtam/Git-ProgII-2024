using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace U1___Problema_5_v2.Datos.Repositories
{
    abstract class Repository<T> : IRepository<T>
    {
        protected DBHelper _helper;
        public Repository()
        {
            _helper = DBHelper.ObtenerInstancia();
        }
        public abstract bool Delete(int id);
        public abstract List<T> GetAll();
        public abstract T GetByID(int id);
        public abstract bool Save(T o);
    }
}
