using System.Text.Json;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Servicios
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
                    "1-Mostrar ultimas n Facturas\n" +
                    "2-Cargar Nueva Factura\n" +
                    "3-Eliminar Factura\n" +
                    "4-Volver al menu principal\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        List<Factura> facturas = facturaManager.ObtenerFacturas();
                        //Console.WriteLine(JsonSerializer.Serialize()
                        foreach (Factura f in facturas)
                        {
                            Console.WriteLine("##########################################################");
                            Console.WriteLine(f.ToString());
                        }
                        break;
                    case "2":
                        facturaManager.GuardarFactura();
                        break;
                    case "3":
                        Console.WriteLine("Implementacion para eliminar una factura");
                        break;
                    case "4":
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
