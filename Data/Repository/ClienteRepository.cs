using Microsoft.EntityFrameworkCore;
using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly AppDbContext _appDbcontext;
        public ClienteRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<Cliente>> GetAllClientesByEstadoActivoAsync()
        {
            return await _appDbcontext.Clientes
                .Where(c => c.EstadoCliente == "Activo")
                .ToListAsync();
            
        }










    }
}
