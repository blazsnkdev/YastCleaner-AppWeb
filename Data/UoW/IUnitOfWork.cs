using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.UoW
{
    public interface IUnitOfWork
    {
        //REPOSITORIOS GENERICOS
        IRepository<TipoServicio> TipoServicio { get; }
        IRepository<Cliente> Cliente { get; }
        IRepository<Prenda> Prenda { get; }
        IRepository<EstadoOrden> EstadoOrden { get; }


        //REPOSITORIOS ESPECIFICOS
        IClienteRepository ClienteRepository { get; }
        ITipoServicioRepository TipoServicioRepository { get; }
        IPrendaRepository PrendaRepository { get; }




        //GUARDAR EN LA BD DE LA MEMORIA
        Task<int> SaveChangesAsync();

    }
}
