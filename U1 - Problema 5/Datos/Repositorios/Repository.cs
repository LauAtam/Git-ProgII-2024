using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Datos.Repositorios
{
    public abstract class Repository<TObject> : IRepository<TObject>
    {
        protected DBHelper _helper;
        protected Repository()
        {
            _helper = DBHelper.ObtenerInstancia();
        }
        public abstract bool Eliminar(int id);
        public abstract List<TObject> ObtenerTodos();
        public abstract TObject ObtenerPorId(int id);
        public abstract bool Guardar(TObject o);
    }
}
