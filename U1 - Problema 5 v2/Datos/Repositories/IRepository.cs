using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Datos.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        bool Save(T o);
        bool Delete(int id);

    }
}
