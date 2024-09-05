using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Datos.Repositories
{
    public interface IRepository<TObject>
    {
        List<TObject> GetAll();
        TObject GetByID(int id);
        bool Save(TObject o);
        bool Delete(int id);

    }
}
