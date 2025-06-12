namespace YAST_CLENAER_WEB.Models.Entity
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public string IdEmpleadoAuth0 { get; set; }
        public int IdEstadoOrden { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntregaEstimada { get; set; }
        public DateTime? FechaEntregaReal { get; set; }
        public decimal Total { get; set; }
        public string Notas { get; set; }

        public Cliente Cliente { get; set; }
        public EstadoOrden EstadoOrden { get; set; }
        public ICollection<DetalleOrden> DetallesOrden { get; set; } = new List<DetalleOrden>();


    }
}
