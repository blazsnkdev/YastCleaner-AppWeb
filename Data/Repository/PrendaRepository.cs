using Microsoft.EntityFrameworkCore;
using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Repository
{
    public class PrendaRepository : Repository<Prenda>, IPrendaRepository
    {
        private readonly AppDbContext _appDbContext;
        public PrendaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Prenda>> GetAllPrendasByEstadoActivoAsync()
        {
            return await _appDbContext.Prendas
                .Where(p => p.EstadoPrenda == "Activo")
                .ToListAsync();
        }

        public async Task UpdatePrendaEstadoActivado(int id)
        {
            var prenda = await _appDbContext.Prendas.FindAsync(id);
            if (prenda != null && prenda.EstadoPrenda == "Desactivado")
            {
                prenda.EstadoPrenda = "Activo";
                _appDbContext.Prendas.Update(prenda);
            }
        }

        public async Task UpdatePrendaEstadoDesactivado(int id)
        {
            var prenda = await _appDbContext.Prendas.FindAsync(id);
            if (prenda != null && prenda.EstadoPrenda == "Activo")
            {
                prenda.EstadoPrenda = "Desactivado";
                _appDbContext.Prendas.Update(prenda);
            }
        }
    }
}
