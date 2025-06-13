using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Services.Impl
{
    public class PrendaService : IPrendaService
    {

        private readonly IUnitOfWork _UoW;
        public PrendaService(IUnitOfWork uow)
        {
            _UoW = uow;
        }

        public async Task ActivarEstadoPrendaByIdAsync(int id)
        {
            await _UoW.PrendaRepository.UpdatePrendaEstadoActivado(id);
            await _UoW.SaveChangesAsync();
        }
        public async Task DesactivarEstadoPrendaByIdAsync(int id)
        {
            await _UoW.PrendaRepository.UpdatePrendaEstadoDesactivado(id);
            await _UoW.SaveChangesAsync();
        }


        public async Task AddPrendaAsync(PrendaViewModel model)
        {
            model.FechaRegistro = DateTime.Now;
            model.EstadoPrenda = "Activo";
            var prenda = new Prenda
            {
                TipoPrenda = model.TipoPrenda,
                Descripcion = model.Descripcion,
                FechaRegistro = model.FechaRegistro,
                EstadoPrenda = model.EstadoPrenda
            };

            await _UoW.Prenda.AddAsync(prenda);
            await _UoW.SaveChangesAsync();
        }

        public async Task<int> ContarTotalPrendasAsync(string? estado)
        {
            var prendas = await _UoW.PrendaRepository.GetAllPrendasByEstadoActivoAsync();
            return prendas.Count();
        }

        
        public async Task<List<PrendaViewModel>> GetAllPrendasPaginaByEstadoAsync(string? estado, int pagina, int tamañoPagina)
        {
            var prendas = await _UoW.PrendaRepository.GetAllPrendasByEstadoActivoAsync();
            var prendaViewModels = prendas
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .Select(p => new PrendaViewModel
                {
                    IdPrenda = p.IdPrenda,
                    TipoPrenda = p.TipoPrenda,
                    Descripcion = p.Descripcion,
                    FechaRegistro = p.FechaRegistro,
                    EstadoPrenda = p.EstadoPrenda
                }).ToList();
            return prendaViewModels;

        }

        public async Task<PrendaViewModel?> GetPrendaByIdAsync(int id)
        {
            var prenda = await _UoW.Prenda.GetByIdAsync(id);
            if (prenda == null)
            {
                return null;
            }

            return new PrendaViewModel
            {
                IdPrenda = prenda.IdPrenda,
                TipoPrenda = prenda.TipoPrenda,
                Descripcion = prenda.Descripcion,
                FechaRegistro = prenda.FechaRegistro,
                EstadoPrenda = prenda.EstadoPrenda
            };
        }

        public async Task<bool> UpdatePrendaAsync(PrendaViewModel model)
        {
            var prenda = await _UoW.Prenda.GetByIdAsync(model.IdPrenda);

            if (prenda == null)
            {
                return false;
            }
            prenda.TipoPrenda = model.TipoPrenda;
            prenda.Descripcion = model.Descripcion;
            _UoW.Prenda.UpdateAsync(prenda);
            await _UoW.SaveChangesAsync();
            return true;
        }
    }
}
