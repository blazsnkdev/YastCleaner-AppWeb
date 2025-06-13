using Microsoft.EntityFrameworkCore;
using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Repository
{
    public class TipoServicioRepository : Repository<TipoServicio>, ITipoServicioRepository
    {
        private readonly AppDbContext _appDbcontext;
        public TipoServicioRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task<IEnumerable<TipoServicio>> GetAllByEstadoActivoAsync()
        {
            return await _appDbcontext.TipoServicios
                .Where(ts => ts.EstadoServicio == "Activo")
                .ToListAsync();
        }

        public async Task<IEnumerable<TipoServicio>> GetAllByEstadoDesactivadoAsync()
        {
            return await _appDbcontext.TipoServicios
                .Where(ts => ts.EstadoServicio == "Desactivado")
                .ToListAsync();
        }

        public async Task UpdateEstadoDesactivadoAsync(int id)
        {
            await _appDbcontext.TipoServicios
                .Where(ts => ts.IdTipoServicio == id)
                .ExecuteUpdateAsync(ts => ts.SetProperty(t => t.EstadoServicio, "Desactivado"));
        }









    }
}
