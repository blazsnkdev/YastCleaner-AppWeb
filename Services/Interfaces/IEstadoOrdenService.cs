using YAST_CLENAER_WEB.Models.ViewModels;

namespace YAST_CLENAER_WEB.Services.Interfaces
{
    public interface IEstadoOrdenService
    {


        Task<int> ContarTotalEstadosOrdenAsync();
        Task<List<EstadoOrdenViewModel>> GetAllEstadosOrdenPaginaAsync(int pagina, int tamanioPagina);
        Task<EstadoOrdenViewModel?> GetByIdEstadoOrdenAsync(int id);
        Task CreateEstadoOrdenAsync(EstadoOrdenViewModel model);
        Task<bool> UpdateEstadoOrdenAsync(EstadoOrdenViewModel model);
        Task DeleteEstadoOrdenAsync(int id);

    }
}
