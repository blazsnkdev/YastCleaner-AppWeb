using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Interfaces
{
    public interface IPrendaRepository :IRepository<Prenda>
    {

        Task<IEnumerable<Prenda>> GetAllPrendasByEstadoActivoAsync();

        Task UpdatePrendaEstadoActivado(int id);
        Task UpdatePrendaEstadoDesactivado(int id);
    }
}
