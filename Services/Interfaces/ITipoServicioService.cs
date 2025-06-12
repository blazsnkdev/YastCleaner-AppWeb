using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;

namespace YAST_CLENAER_WEB.Services.Interfaces
{
    public interface ITipoServicioService
    {
        Task<List<TipoServicioViewModel>> GetAllTipoServicioAsyncByEstado(string? filtroEstado);

        Task AddTipoServicioAsync(TipoServicioViewModel model);

    }
}
