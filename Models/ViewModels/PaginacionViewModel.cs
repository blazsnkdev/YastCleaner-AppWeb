namespace YAST_CLENAER_WEB.Models.ViewModels
{
    public class PaginacionViewModel<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public string? FiltroEstado { get; set; }
    }
}
