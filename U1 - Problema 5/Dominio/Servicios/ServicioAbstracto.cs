using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_5.Dominio.Clases;
using U1___Problema_5.Dominio.Interfaces;

namespace U1___Problema_5.Dominio.Servicios
{
    internal class ServicioAbstracto : IServicio
    {
        public void Actualizar()
        {
            throw new NotImplementedException();
        }

        public DataTable Consultar(string sp)
        {
            return AccesoDatos.Consultar(sp);   
        }

        public void Crear()
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string sp, int id)
        {
            AccesoDatos.EjecutarSp(sp, id);
        }
    }
}
