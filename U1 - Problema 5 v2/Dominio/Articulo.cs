using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    internal class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float PrecioUnitario { get; set; }
        public Articulo(int id, string nombre, float precioUnitario)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.PrecioUnitario = precioUnitario;
        }
    }
}
