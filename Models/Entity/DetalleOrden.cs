namespace YAST_CLENAER_WEB.Models.Entity
{
    public class DetalleOrden
    {
        public int IdDetalleOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdTipoServicio { get; set; }
        public int? IdPrenda { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public string Observaciones { get; set; }

        public Orden Orden { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public Prenda Prenda { get; set; }



    }
}
