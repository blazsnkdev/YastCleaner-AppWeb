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
            await _unitOfWork.TipoServicio.AddAsync(tipoServicio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTipoServicioAsync(int id)
        {
            var tipoServicio = await _unitOfWork.TipoServicioRepository.GetByIdAsync(id);
            if (tipoServicio == null)
            {
                throw new ArgumentException("Tipo de servicio no encontrado.");
            }
            _unitOfWork.TipoServicioRepository.DeleteAsync(tipoServicio);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DesactivarEstadoAsync(int id)
        {
            var tipoServicio = await _unitOfWork.TipoServicioRepository.GetByIdAsync(id);
            await _unitOfWork.TipoServicioRepository.UpdateEstadoDesactivadoAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        //public async Task<List<TipoServicioViewModel>> GetAllTipoServicioAsyncByEstado(string? filtroEstado)
        //{
        //    IEnumerable<TipoServicio> lista;
        //    if (!string.IsNullOrEmpty(filtroEstado))
        //        lista = await _unitOfWork.TipoServicioRepository.GetAllByEstadoDesactivadoAsync();
        //    else
        //        lista = await _unitOfWork.TipoServicioRepository.GetAllByEstadoActivoAsync();

        //    var viewModel =lista.Select(t => new TipoServicioViewModel
        //    {
        //        IdTipoServicio = t.IdTipoServicio,
        //        NombreServicio = t.NombreServicio,
        //        Descripcion = t.Descripcion,
        //        PrecioBase = t.PrecioBase,
        //        FechaCreacion = t.FechaCreacion,
        //        EstadoServicio = t.EstadoServicio
        //    }).ToList();
        //    return viewModel;

        //}

        public async Task<List<TipoServicioViewModel>> GetTipoServicioPaginadoAsync(string? estado, int pagina, int tamañoPagina)
        {
            IEnumerable<TipoServicio> lista = string.IsNullOrEmpty(estado)
                ? await _unitOfWork.TipoServicioRepository.GetAllByEstadoActivoAsync()
                : await _unitOfWork.TipoServicioRepository.GetAllByEstadoDesactivadoAsync();

            var resultado = lista
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .Select(t => new TipoServicioViewModel
                {
                    IdTipoServicio = t.IdTipoServicio,
                    NombreServicio = t.NombreServicio,
                    Descripcion = t.Descripcion,
                    PrecioBase = t.PrecioBase,
                    FechaCreacion = t.FechaCreacion,
                    EstadoServicio = t.EstadoServicio
                }).ToList();

            return resultado;
        }

        public async Task<int> ContarTotalTipoServiciosAsync(string? estado)
        {
            IEnumerable<TipoServicio> lista = string.IsNullOrEmpty(estado)
                ? await _unitOfWork.TipoServicioRepository.GetAllByEstadoActivoAsync()
                : await _unitOfWork.TipoServicioRepository.GetAllByEstadoDesactivadoAsync();

            return lista.Count();
        }


        public async Task<TipoServicioViewModel?> GetTipoServicioByIdAsync(int id)
        {
            var tipoServicio = await _unitOfWork.TipoServicioRepository.GetByIdAsync(id);
            
            var viewModel = new TipoServicioViewModel
            {
                IdTipoServicio = tipoServicio.IdTipoServicio,
                NombreServicio = tipoServicio.NombreServicio,
                Descripcion = tipoServicio.Descripcion,
                PrecioBase = tipoServicio.PrecioBase,
                FechaCreacion = tipoServicio.FechaCreacion,
                EstadoServicio = tipoServicio.EstadoServicio
            };
            return viewModel;

        }

        public async Task UpdateTipoServicioAsync(TipoServicioViewModel model)
        {
            var tipoServicio = await _unitOfWork.TipoServicioRepository.GetByIdAsync(model.IdTipoServicio);

            if (tipoServicio == null)

            {
                throw new ArgumentException("Tipo de servicio no encontrado.");
            }

            tipoServicio.NombreServicio = model.NombreServicio;
            tipoServicio.PrecioBase = model.PrecioBase;
            tipoServicio.Descripcion = model.Descripcion;

            _unitOfWork.TipoServicioRepository.UpdateAsync(tipoServicio);
            await _unitOfWork.SaveChangesAsync();
        }





    }
}
