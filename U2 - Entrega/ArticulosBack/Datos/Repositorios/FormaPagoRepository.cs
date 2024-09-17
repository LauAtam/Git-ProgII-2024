using System.Data;
using System.Data.SqlClient;
using FacturacionBack.Modelos;

namespace FacturacionBack.Datos.Repositorios
{
    public class FormaPagoRepository : Repository<FormaPago>
    {
        public override bool Eliminar(FormaPago o)
        {
            throw new NotImplementedException();
        }

        public override bool Guardar(FormaPago o)
        {
            throw new NotImplementedException();
        }

        public override FormaPago ObtenerPorId(int id)
        {
            FormaPago formaPago = new FormaPago();
            DataTable dtFormaPago = _helper.EjecutarSP("SP_RECUPERAR_FORMAS_PAGO_POR_ID", new SqlParameter("@id", id));
            if (dtFormaPago != null && dtFormaPago.Rows.Count > 0)
            {
                foreach (DataRow row in dtFormaPago.Rows)
                {
                    formaPago.Id = (int)row["id"];
                    formaPago.Nombre = (string)row["nombre"];
                }
            }
            return formaPago;
        }

        public override List<FormaPago> ObtenerTodos()
        {
            DataTable dtFormasPago = _helper.EjecutarSP("SP_RECUPERAR_FORMAS_PAGO");
            List<FormaPago> lstFormasPago = new List<FormaPago>();
            if (dtFormasPago!= null && dtFormasPago.Rows.Count > 0)
            {
                foreach (DataRow row in dtFormasPago.Rows)
                {
                    lstFormasPago.Add(new FormaPago(){Id = (int)row["id"],Nombre = (string)row["nombre"]});
                }
            }
            return lstFormasPago;
        }
    }
}