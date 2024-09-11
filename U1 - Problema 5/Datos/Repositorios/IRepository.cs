using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Datos.Repositorios
{
    public interface IRepository<TObject>
    {
        List<TObject> ObtenerTodos();
        TObject ObtenerPorId(int id);
        bool Guardar(TObject o);
        bool Eliminar(int id);
    }
}
