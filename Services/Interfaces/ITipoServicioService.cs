using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;

namespace YAST_CLENAER_WEB.Services.Interfaces
{
    public interface ITipoServicioService
    {
        //Task<List<TipoServicioViewModel>> GetAllTipoServicioAsyncByEstado(string? filtroEstado);
        Task<int> ContarTotalTipoServiciosAsync(string? estado);
        Task<List<TipoServicioViewModel>> GetTipoServicioPaginadoAsync(string? estado, int pagina, int tamañoPagina);

        Task AddTipoServicioAsync(TipoServicioViewModel model);
        Task<TipoServicioViewModel?> GetTipoServicioByIdAsync(int id);
        Task UpdateTipoServicioAsync(TipoServicioViewModel model);
        Task DeleteTipoServicioAsync(int id);

        Task DesactivarEstadoAsync(int id);
    }
}
