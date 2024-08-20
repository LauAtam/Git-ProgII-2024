using U1___Problema_1.Clases;

namespace U1___Problema_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\r----------------------");
            Pila pagoFacil = new Pila(10);
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            foreach (int numero in numeros)
            {
                Console.WriteLine(pagoFacil.añadir(numero));                
            }
            Console.WriteLine(pagoFacil.primero());
            pagoFacil.toString(); Console.WriteLine();
            Console.WriteLine(pagoFacil.extraer());
            pagoFacil.toString();Console.WriteLine();
            pagoFacil.añadir(33);
            pagoFacil.toString(); Console.WriteLine();

            Console.ReadLine();
        }
    }
}
