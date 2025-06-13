using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Services.Impl
{
    public class EstadoOrdenService : IEstadoOrdenService
    {

        private readonly IUnitOfWork _UoW;
        public EstadoOrdenService(IUnitOfWork uow)
        {
            _UoW = uow;
        }

        public async Task<int> ContarTotalEstadosOrdenAsync()
        {
            var totalEstadosOrden = await _UoW.EstadoOrden.GetAllAsync();
            return totalEstadosOrden.Count();
        }

        public async Task CreateEstadoOrdenAsync(EstadoOrdenViewModel model)
        {
            var estadoOrdenEntity = new EstadoOrden
            {
                NombreEstado = model.NombreEstado
            };

            await _UoW.EstadoOrden.AddAsync(estadoOrdenEntity);
            await _UoW.SaveChangesAsync();
        }

        public async Task DeleteEstadoOrdenAsync(int id)
        {
            var estadoOrden = await _UoW.EstadoOrden.GetByIdAsync(id);
            if (estadoOrden != null)
            {
                _UoW.EstadoOrden.DeleteAsync(estadoOrden);
            }
        }

        public async Task<List<EstadoOrdenViewModel>> GetAllEstadosOrdenPaginaAsync(int pagina, int tamanioPagina)
        {
            var estadoOrdenes = await _UoW.EstadoOrden.GetAllAsync();
            var viewModel = estadoOrdenes
                .Skip((pagina-1)*tamanioPagina)
                .Take(tamanioPagina)
                .Select(e => new EstadoOrdenViewModel
                {
                    IdEstadoOrden = e.IdEstadoOrden,
                    NombreEstado = e.NombreEstado
                }).ToList();

            return viewModel;
        }

        public async Task<EstadoOrdenViewModel?> GetByIdEstadoOrdenAsync(int id)
        {
            var estadoOrden = await _UoW.EstadoOrden.GetByIdAsync(id);
            if (estadoOrden == null) return null;
            var viewModel = new EstadoOrdenViewModel
            {
                IdEstadoOrden = estadoOrden.IdEstadoOrden,
                NombreEstado = estadoOrden.NombreEstado
            };
            return viewModel;
        }

        public async Task<bool> UpdateEstadoOrdenAsync(EstadoOrdenViewModel model)
        {
            var estadoOrden = await _UoW.EstadoOrden.GetByIdAsync(model.IdEstadoOrden);
            if (estadoOrden == null) return false;
            estadoOrden.NombreEstado = model.NombreEstado;
            _UoW.EstadoOrden.UpdateAsync(estadoOrden);
            await _UoW.SaveChangesAsync();
            return true;

        }

    }
}
