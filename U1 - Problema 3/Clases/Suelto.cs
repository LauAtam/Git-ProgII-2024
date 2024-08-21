using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U1___Problema_3.ClasesAbstractas;

namespace U1___Problema_3.Clases
{
    internal class Suelto : ProductoAbstracto
    {
        public float medida;

        public Suelto(float medida, int codigo, string nombre, float precio) : base(codigo, nombre, precio)
        {
            this.medida = medida;
        }

        public override float CalcularPrecio()
        {
            return medida * precio;
        }
    }
}
