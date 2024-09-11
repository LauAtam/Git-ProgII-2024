using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Datos.Repositorios
{
    public class FacturaRepository
    {
        private DBHelper _helper;
        public FacturaRepository()
        {
            _helper = DBHelper.ObtenerInstancia();
        }
    }
}
