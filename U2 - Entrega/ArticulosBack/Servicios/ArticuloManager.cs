using FacturacionBack.Datos.Repositorios;
using FacturacionBack.Modelos;

namespace FacturacionBack.Servicios
{
    public class ArticuloManager
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

        public List<Articulo> ObtenerArticulos()
        {
            return _articuloRepository.ObtenerTodos();
        }

        public bool RegistrarArticulo(Articulo articulo)
        {
            return _articuloRepository.Guardar(articulo);
        }

        public bool EliminarArticulo(Articulo articulo)
        {
            return _articuloRepository.Eliminar(articulo);
        }
    }
}