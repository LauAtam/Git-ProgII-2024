namespace FacturacionDDL.Modelos
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nombre}\t${PrecioUnitario}";
        }
    }
}
