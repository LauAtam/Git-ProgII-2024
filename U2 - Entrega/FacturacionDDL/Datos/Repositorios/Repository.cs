using System.Collections.Generic;

namespace FacturacionDDL.Datos.Repositorios
{
    public abstract class Repository<TObject> : IRepository<TObject>
    {
        protected DBHelper _helper = DBHelper.ObtenerInstancia();
        public abstract bool Eliminar(TObject o);
        public abstract List<TObject> ObtenerTodos();
        public abstract TObject ObtenerPorId(int id);
        public abstract bool Guardar(TObject o);
    }
}
