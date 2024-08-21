using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_3.Interfaces;

namespace U1___Problema_3.ClasesAbstractas
{
    internal abstract class ProductoAbstracto : IPrecio
    {
        public int codigo;
        public string nombre;
        public float precio;
        protected ProductoAbstracto(int codigo, string nombre, float precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
        }

        public abstract float CalcularPrecio();
    }
}
