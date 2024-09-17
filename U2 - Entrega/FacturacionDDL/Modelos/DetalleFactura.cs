namespace FacturacionDDL.Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int NroDetalle { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
