using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_1.Interfaces
{
    internal abstract class CollectionAbstracta : ICollection
    {
        public object[] objetos;
        protected int next;
        public CollectionAbstracta(int tamaño)
        {
            objetos = new object[tamaño];
            next = -1;
        }
        public virtual bool añadir(object objeto)
        {
            bool añadido = false;
            if (next < objetos.Length-1)
            {
                objetos[++next] = objeto;
                añadido = true;
            }
            return añadido;
        }

        public bool estaVacia()
        {
            return next == -1;
        }

        public abstract object extraer();

        public object primero()
        {
            return objetos.First();
        }

        public void toString()
        {
            foreach (object o in objetos)
            {
                Console.Write($"{o} - ");
            }
        }
    }
}
