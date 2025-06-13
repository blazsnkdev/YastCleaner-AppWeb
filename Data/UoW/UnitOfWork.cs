using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        //REPOSITORIOS GENERICO
        public IRepository<TipoServicio> TipoServicio { get; }
        public IRepository<Cliente> Cliente { get; }

        //REPOSITORIO ESPECIFICO
        public ITipoServicioRepository TipoServicioRepository { get;}
        public IClienteRepository ClienteRepository { get; }


        //CONTEXT
        public readonly AppDbContext _appDbcontext;
        //CONSTRUCTOR
        public UnitOfWork(AppDbContext appDbContext,
            IRepository<TipoServicio> tipoServicio,
            ITipoServicioRepository tipoServicioRepository,
            IRepository<Cliente> cliente,
            IClienteRepository clienteRepository)
        {
            _appDbcontext = appDbContext;
            TipoServicio = tipoServicio;
            TipoServicioRepository = tipoServicioRepository;
            Cliente = cliente;
            ClienteRepository = clienteRepository;
        }

        //GUARDAR EN LA BD LOS CAMBIOS DE MEMORIA
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbcontext.SaveChangesAsync();
        }
    }
}
