using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesByEstadoActivoAsync();
        
    }
}
