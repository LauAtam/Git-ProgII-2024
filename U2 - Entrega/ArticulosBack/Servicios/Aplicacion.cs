using System.Text.Json;
using FacturacionBack.Modelos;

namespace FacturacionBack.Servicios
{
    public class Aplicacion
    {
        public static void MenuPrincipal()
        {
            bool programa = true;
            while (programa)
            {
                Console.WriteLine(
                    $"--Menu Principal--\n" +
                    $"1- Opciones Facturas\n" +
                    $"2- Opciones Articulos\n" +
                    $"3- Opciones Formas de pago\n" +
                    $"4- Salir.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        MenuFacturas();
                        break;
                    case "2":
                        MenuArticulos();
                        break;
                    case "3":
                        MenuFormasDePago();
                        break;
                    case "4":
                        programa = false;
                        break;
                    default:
                        Console.WriteLine("Debe ingresar una opcion válida");
                        break;
                }
            }
        }

        #region Menu Gestion Facturas
        private static void MenuFacturas()
        {
            FacturaManager facturaManager = new FacturaManager();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine(
                    "--Gestion de Facturas--\n" +
                    "1-Mostrar Facturas\n" +
                    "2-Cargar Nueva Factura\n" +
                    "3-Eliminar Factura\n" +
                    "4-Volver al menu principal\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        facturaManager.ObtenerFacturas();
                        break;
                    case "2":
                        facturaManager.GuardarFactura();
                        break;
                    case "3":
                        facturaManager.EliminarFactura();
                        break;
                    case "4":
                        Console.WriteLine("Debe ingresar una opcion válida");
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private static void MenuArticulos()
        {
            Console.WriteLine(
                "--Gestion de Articulos--\n");
        }

        private static void MenuFormasDePago()
        {
            Console.WriteLine(
                "--Gestion de Formas de pago--\n");
        }
    }
}
