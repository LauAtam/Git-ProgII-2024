namespace WebAPI_prueba.Models
{
    public class Moneda
    {
        public string Nombre { get; set; }
        public int ValorEnPesos { get; set; }
        public override string ToString()
        {
            return $"Nombre: {Nombre}\nValor En Pesos: {ValorEnPesos}";
        }
    }
}
