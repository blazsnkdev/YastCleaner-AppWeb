using YAST_CLENAER_WEB.Models.ViewModels;

namespace YAST_CLENAER_WEB.Services.Interfaces
{
    public interface IPrendaService
    {
        Task<List<PrendaViewModel>> GetAllPrendasPaginaByEstadoAsync(string? estado, int pagina, int tamañoPagina);
        Task<int> ContarTotalPrendasAsync(string? estado);
        Task AddPrendaAsync(PrendaViewModel model);
        Task<bool> UpdatePrendaAsync(PrendaViewModel model);
        Task<PrendaViewModel?> GetPrendaByIdAsync(int id);
        Task DesactivarEstadoPrendaByIdAsync(int id);
        Task ActivarEstadoPrendaByIdAsync(int id);
    }
}
