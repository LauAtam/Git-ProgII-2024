using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Dominio.Interfaces
{
    public interface IServicio
    {
        void Crear();
        void Actualizar();

        DataTable Consultar(string sp);
        void Eliminar();

        
    }
}
