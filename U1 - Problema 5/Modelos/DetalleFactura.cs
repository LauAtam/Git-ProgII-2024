using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5.Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int NroDetalle { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
