using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class DetalleFactura
    {
        public int id { get; set; }
        public int idFactura { get; set; }
        public int idArticulo { get; set; }
        public int cantidad { get; set; }
    }
}
