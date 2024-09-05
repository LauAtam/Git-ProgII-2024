using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    internal class Articulo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precioUnitario { get; set; }
        public Articulo(int id, string nombre, float precioUnitario)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
        }
    }
}
