using YAST_CLENAER_WEB.Models.ViewModels;

namespace YAST_CLENAER_WEB.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteViewModel>> GetAllClientesPaginaByEstadoAsync(string? estado, int pagina, int tamañoPagina);

        Task<int> ContarTotalClientesAsync(string? estado);

        Task AddClienteAsync(ClienteViewModel model);
        Task<bool> UpdateClienteAsync(ClienteViewModel model);

        Task<ClienteViewModel?> GetClienteByIdAsync(int id);

        Task DesactivarEstadoClienteByIdAsync(int id);


    }
}
