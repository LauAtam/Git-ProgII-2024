
using U1___Problema_5.Datos.Repositorios;
using U1___Problema_5.Modelos;

namespace U1___Problema_5.Servicios
{
    internal class ArticuloManager
    {
        private ArticuloRepository _articuloRepository = new ArticuloRepository();

        internal Articulo SeleccionarArticulo()
        {
            bool validInput = false;
            int index = 0;
            List<Articulo> lstArticulos = _articuloRepository.ObtenerTodos();
            while (!validInput)
            {
                foreach (Articulo articulo in lstArticulos)
                {
                    Console.WriteLine($"{articulo.ToString()}");
                }
                Console.Write($"\nSeleccione un artículo: ");
                var input = Console.ReadLine();
                validInput = int.TryParse(input, out index);
                index--;
                if (index > lstArticulos.Count || index < 0)
                    validInput = false;
            }
            return lstArticulos[index];
        }
    }
}