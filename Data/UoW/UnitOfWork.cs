using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        //REPOSITORIOS
        public IRepository<TipoServicio> TipoServicio { get; }
        public ITipoServicioRepository TipoServicioRepository { get;}



        //CONTEXT
        public readonly AppDbContext _appDbcontext;
        //CONSTRUCTOR
        public UnitOfWork(AppDbContext appDbContext,
            IRepository<TipoServicio> tipoServicio,
            ITipoServicioRepository tipoServicioRepository)
        {
            _appDbcontext = appDbContext;
            TipoServicio = tipoServicio;
            TipoServicioRepository = tipoServicioRepository;
        }
        //GUARDAR EN LA BD LOS CAMBIOS DE MEMORIA
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbcontext.SaveChangesAsync();
        }
    }
}
