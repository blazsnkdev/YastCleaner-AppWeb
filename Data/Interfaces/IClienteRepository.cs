using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllClientesByEstadoActivoAsync();

        Task UpdateEstadoDesactivadoAsync(int id);
        
    }
}
