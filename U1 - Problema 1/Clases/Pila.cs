using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_1.Interfaces;

namespace U1___Problema_1.Clases
{
    internal class Pila : CollectionAbstracta
    {
        public Pila(int tamaño) : base(tamaño)
        {
        }

        public override object extraer()
        {
            object ultimo = objetos[next];
            objetos[next--] = null;
            return ultimo;
        }
    }
}
