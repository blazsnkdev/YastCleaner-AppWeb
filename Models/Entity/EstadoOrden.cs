namespace YAST_CLENAER_WEB.Models.Entity
{
    public class EstadoOrden
    {
        public int IdEstadoOrden { get; set; }
        public string NombreEstado { get; set; }

        public ICollection<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}
