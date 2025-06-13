using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TipoServicioController : Controller
    {

        private readonly ITipoServicioService _service;
        public TipoServicioController(ITipoServicioService service)
        {
            _service = service;
        }
        [Route("tipoServicio/lista")]
        public async Task<IActionResult> Index(string? filtroEstado, int pagina = 1)
        {
            int tamañoPagina = 5;

            var totalItems = await _service.ContarTotalTipoServiciosAsync(filtroEstado);
            var items = await _service.GetTipoServicioPaginadoAsync(filtroEstado, pagina, tamañoPagina);

            var viewModel = new PaginacionViewModel<TipoServicioViewModel>
            {
                Items = items,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)totalItems / tamañoPagina),
                FiltroEstado = filtroEstado
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _service.GetTipoServicioByIdAsync(id);
            if (model == null)
            {
                TempData["ErrorMessage"] = "El servicio no existe.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                await _service.DesactivarEstadoAsync(id);
                TempData["SuccessMessage"] = "El servicio se ha desactivado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex}";
            }
            return RedirectToAction("Index");
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TipoServicioViewModel model)
        {
            try
            {
                await _service.AddTipoServicioAsync(model);
                TempData["SuccessMessage"] = "El servicio se ha creado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex){
                TempData["ErrorMessage"] = $"Error: {ex}";
                return RedirectToAction("Index", model);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _service.GetTipoServicioByIdAsync(id);
            if (model == null)
            {
                TempData["ErrorMessage"] = "El servicio no existe.";
                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(TipoServicioViewModel model)
        {
            try
            {
                await _service.UpdateTipoServicioAsync(model);
                TempData["SuccessMessage"] = "El servicio se ha actualizado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex}";
                return View(model);
            }
        }




    }
}
