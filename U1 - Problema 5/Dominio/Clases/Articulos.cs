using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Dominio.Clases
{
    internal class Articulos
    {
        private int id;
        private string nombre;
        private float precioUnitario;

        public Articulos(int id,string nombre,float precioU)
        {
            this.id = id;
            this.nombre = nombre;
            precioUnitario = precioU;
        }
        public Articulos()
        {
            id = 0;
            nombre = string.Empty;
            precioUnitario=0;
        }
    }
}
