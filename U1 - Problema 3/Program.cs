using System.IO.Pipes;
using U1___Problema_3.Clases;
using U1___Problema_3.ClasesAbstractas;

namespace U1___Problema_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductoAbstracto[] productos = new ProductoAbstracto[10];
            productos[0] = new Pack(2, 1, "pack 1", 10);
            productos[2] = new Pack(3, 3, "pack 3", 10);
            productos[4] = new Pack(4, 5, "pack 5", 10);
            productos[6] = new Pack(5, 7, "pack 7", 10);
            productos[8] = new Pack(6, 9, "pack 9", 10);
            productos[1] = new Suelto(100, 2, "suelto 2", 10f);
            productos[3] = new Suelto(100, 4, "suelto 4", 2f);
            productos[5] = new Suelto(100, 6, "suelto 6", 5.50f);
            productos[7] = new Suelto(100, 8, "suelto 8", 4.50f);
            productos[9] = new Suelto(100, 10, "suelto 10", 20f);
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|Codigo\t|Nombre     \t|Precio\t|Precio por cantidad/stock|");
            foreach (ProductoAbstracto producto in productos)
            {
                Console.WriteLine($"|{producto.codigo}\t|{producto.nombre}     \t|{producto.precio}\t|{producto.CalcularPrecio()}|");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }
    }
}