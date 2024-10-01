using System.Text.RegularExpressions;
using U1___Problema_5.Datos.Repositorios;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Servicios
{
    public class FormaPagoManager
    {
        private FormaPagoRepository _formaPagoRepository = new FormaPagoRepository();

        public FormaPago? SeleccionarFormaPago()
        {
            bool validInput = false;
            int index = 0;
            List<FormaPago> lstFormasPago = _formaPagoRepository.ObtenerTodos();
            while (!validInput)
            {
                foreach (FormaPago formaPago in lstFormasPago)
                {
                    Console.WriteLine($"{formaPago.ToString()}");
                }
                Console.Write($"\nSeleccione una forma de pago: ");
                var input = Console.ReadLine();
                validInput = int.TryParse(input, out index);
                index--;
                if (index > lstFormasPago.Count || index < 0)
                    validInput = false;
            }
            return lstFormasPago[index];
        }
    }
}