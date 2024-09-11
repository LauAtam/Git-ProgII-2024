using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using U1___Problema_5_v2.Dominio;

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
                        break;
                }
            }
        }

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
                        Console.Write("Ingrese la cantidad de facturas que desea ver: ");
                        input = Console.ReadLine();
                        int n;
                        int.TryParse(input, out n);
                        facturaManager.ObtenerFacturas(n);
                        break;
                    case "2":
                        facturaManager.GuardarFactura();
                        break;
                    case "3":
                        MenuFormasDePago();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
        }

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
