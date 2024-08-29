using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace U1___Problema_5_v2.Datos.Daos
{
    abstract class DaoAbstracto : IDAO
    {
        public DBHelper _helper = DBHelper.ObtenerInstancia();
        public abstract bool DeleteByID(object o);
        public abstract List<object> GetAll();
        public abstract object GetByID(int id);
        public abstract bool Insert(object o);
        public abstract bool UpdateByID(object o);
    }
}
