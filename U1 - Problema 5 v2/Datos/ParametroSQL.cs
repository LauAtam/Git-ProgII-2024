using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Datos
{
    public class ParametroSQL
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }
        public ParametroSQL(string nombre, object valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
