namespace FacturacionBack.Modelos
{
    public class FormaPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Id - Nombre</returns>
        public override string ToString()
        {
            return $"{Id} - {Nombre}";
        }
    }
}
