using System.Collections.Generic;

namespace FacturacionDDL.Datos.Repositorios
{
    public interface IRepository<TObject>
    {
        List<TObject> ObtenerTodos();
        TObject ObtenerPorId(int id);
        bool Guardar(TObject o);
        bool Eliminar(TObject o);
    }
}
