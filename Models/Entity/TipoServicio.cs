namespace YAST_CLENAER_WEB.Models.Entity
{
    public class TipoServicio
    {
        public int IdTipoServicio { get; set; }
        public string NombreServicio { get; set; }
        public decimal PrecioBase { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string EstadoServicio { get; set; }

        public ICollection<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();
    }
}
