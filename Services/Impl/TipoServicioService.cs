using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Services.Impl
{
    public class TipoServicioService : ITipoServicioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTipoServicioAsync(TipoServicioViewModel model)
        {
            model.FechaCreacion = DateTime.Now;
            model.EstadoServicio = "Activo";
            
            var tipoServicio = new TipoServicio
            {
                NombreServicio = model.NombreServicio,
                PrecioBase = model.PrecioBase,
                Descripcion = model.Descripcion,
                FechaCreacion = model.FechaCreacion,
                EstadoServicio = model.EstadoServicio
            };
            await _unitOfWork.TipoServicioRepository.AddAsync(tipoServicio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TipoServicioViewModel>> GetAllTipoServicioAsyncByEstado(string? filtroEstado)
        {
            IEnumerable<TipoServicio> lista;
            if (!string.IsNullOrEmpty(filtroEstado))
                lista = await _unitOfWork.TipoServicioRepository.GetAllByEstadoDesactivadoAsync();
            else
                lista = await _unitOfWork.TipoServicioRepository.GetAllByEstadoActivoAsync();

            var viewModel =lista.Select(t => new TipoServicioViewModel
            {
                IdTipoServicio = t.IdTipoServicio,
                NombreServicio = t.NombreServicio,
                Descripcion = t.Descripcion,
                PrecioBase = t.PrecioBase,
                FechaCreacion = t.FechaCreacion,
                EstadoServicio = t.EstadoServicio
            }).ToList();
            return viewModel;

        }
    }
}
