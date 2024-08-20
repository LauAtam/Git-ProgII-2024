using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_1.Interfaces;

namespace U1___Problema_1.Clases
{
    internal class Cola : CollectionAbstracta
    {
        public Cola(int tamaño) : base(tamaño)
        {
        }

        public override object extraer()
        {
            object primero = objetos.First();
            if (!estaVacia())
            {
                for (int i = 0; i < objetos.Length - 1; i++)
                {
                    objetos[i] = objetos[i + 1];
                }
                objetos[next--] = null;
            }
            return primero;
        }
    }
}
