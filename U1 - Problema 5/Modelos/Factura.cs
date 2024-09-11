using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public FormaPago FormaPago { get; set; }
        public string NombreCliente { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
    }
}
