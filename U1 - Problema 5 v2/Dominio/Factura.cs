using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class Factura
    {
        public int Id;
        public DateTime Fecha;
        public int IdFormaPago;
        public string NombreCliente;
        public Factura(int id, DateTime fecha, int idFormaPago, string nombreCliente)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.IdFormaPago = idFormaPago;
            this.NombreCliente = nombreCliente;
        }
    }
}
