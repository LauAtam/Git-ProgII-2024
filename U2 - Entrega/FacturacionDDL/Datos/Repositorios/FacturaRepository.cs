﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FacturacionDDL.Modelos;

namespace FacturacionDDL.Datos.Repositorios
{
    public class FacturaRepository : Repository<Factura>
    {
        private IRepository<FormaPago> formaPagoRepository = new FormaPagoRepository();
        private DetalleFacturaRepository detalleFacturaRepository = new DetalleFacturaRepository();

        /// <summary>
        /// Elimina una factura por su atributo Id y todos los Detalles de la misma
        /// </summary>
        /// <param name="factura"></param>
        /// <returns>Bool que representa si se eliminó algun registro</returns>
        public override bool Eliminar(Factura factura)
        {
            int lineas = 0;
            foreach (DetalleFactura detalle in factura.Detalles)
            {
                List<SqlParameter> paramsDetalle = new List<SqlParameter>()
                {
                    new SqlParameter("@id", factura.Id)
                };
                lineas += _helper.EjecutarSPDML("SP_ELIMINAR_DETALLE_FACTURA", paramsDetalle);
            }
            List<SqlParameter> paramsFactura = new List<SqlParameter>()
            {
                new SqlParameter("@id", factura.Id)
            };
            lineas += _helper.EjecutarSPDML("SP_ELIMINAR_FACTURA", paramsFactura);
            return lineas > 0;
        }
        /// <summary>
        /// Guarda en la base de datos la factura y sus detalles
        /// </summary>
        /// <param name="factura"></param>
        /// <returns></returns>
        public override bool Guardar(Factura factura)
        {
            int contadorDetalles = 0;
            string spMaestro = "SP_GUARDAR_FACTURA";
            string spDetalle = "SP_GUARDAR_DETALLE_FACTURA";
            List<SqlParameter> maestro = new List<SqlParameter>()
            {
                new SqlParameter("@id", factura.Id),
                new SqlParameter("@id_forma_pago", factura.FormaPago.Id),
                new SqlParameter("@nombre_cliente", factura.NombreCliente),
            };
            List<List<SqlParameter>> detalles = new List<List<SqlParameter>>();
            foreach (DetalleFactura detalle in factura.Detalles)
            {
                contadorDetalles++;
                detalles.Add(new List<SqlParameter>()
                {
                    new SqlParameter("@id", detalle.Id),
                    new SqlParameter("@nro_detalle", contadorDetalles),
                    new SqlParameter("@id_articulo", detalle.Articulo.Id),
                    new SqlParameter("@cantidad", detalle.Cantidad)
                });
            }
            return _helper.ConsultaSPDMLMaestroDetalle(spMaestro, spDetalle, maestro, detalles);
        }

        public override Factura ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Factura> ObtenerTodos()
        {
            DataTable dtFacturas = _helper.EjecutarSP("SP_RECUPERAR_FACTURAS");
            List<Factura> lstFacturas = new List<Factura>();
            if (dtFacturas != null && dtFacturas.Rows.Count > 0)
            {
                foreach (DataRow row in dtFacturas.Rows)
                {
                    Factura factura = new Factura()
                    {
                        Id = (int)row["id"],
                        Fecha = (DateTime)row["fecha"],
                        FormaPago = formaPagoRepository.ObtenerPorId((int)row["id_forma_pago"]),
                        NombreCliente = (string)row["nombre_cliente"],
                        Detalles = detalleFacturaRepository.ObtenerPorIdMaestro((int)row["id"])
                    };
                    lstFacturas.Add(factura);
                }
            }
            return lstFacturas;
        }
    }
}
