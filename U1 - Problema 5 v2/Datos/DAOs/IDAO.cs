using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Datos.Daos
{
    public interface IDAO
    {
        public List<object> GetAll();
        public object GetByID(int id);
        public bool Insert(object o);
        public bool UpdateByID(object o);
        public bool DeleteByID(object o);

    }
}
