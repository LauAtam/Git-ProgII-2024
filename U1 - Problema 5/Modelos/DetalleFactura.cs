﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1___Problema_5_v2.Dominio
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
