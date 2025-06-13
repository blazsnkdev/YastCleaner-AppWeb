using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Interfaces
{
    public interface ITipoServicioRepository : IRepository<TipoServicio>
    {
        Task<IEnumerable<TipoServicio>> GetAllByEstadoActivoAsync();
        Task<IEnumerable<TipoServicio>> GetAllByEstadoDesactivadoAsync();
        Task UpdateEstadoDesactivadoAsync(int id);

    }
}
