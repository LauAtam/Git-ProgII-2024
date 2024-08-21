using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_3.ClasesAbstractas;

namespace U1___Problema_3.Clases
{
    internal class Pack : ProductoAbstracto
    {
        public int cantidad;
        public Pack(int cantidad, int codigo, string nombre, float precio) : base(codigo, nombre, precio)
        {
            this.cantidad = cantidad;
        }

        public override float CalcularPrecio()
        {
            return cantidad * precio;
        }
    }
}
