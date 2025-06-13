using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Controllers
{
    [Authorize(Roles = "Admin,Empleado")]
    public class PrendaController : Controller
    {

        private readonly IPrendaService _service;
        public PrendaController(IPrendaService service)
        {
            _service = service;
        }
        public IActionResult Index(string? filtroEstado, int pagina = 1)
        {
            int tamañoPagina = 5;
            var prendas = _service.GetAllPrendasPaginaByEstadoAsync(filtroEstado, pagina, tamañoPagina).Result;
            var totalItems = _service.ContarTotalPrendasAsync(filtroEstado).Result;


            var viewModel = new PaginacionViewModel<PrendaViewModel>
            {
                Items = prendas,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)totalItems / tamañoPagina),
                FiltroEstado = filtroEstado
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var prenda = await _service.GetPrendaByIdAsync(id);
            if (prenda == null)
            {
                TempData["ErrorMessage"] = "Prenda no encontrada.";
                return RedirectToAction("PageNotFound"); // AGREGAR
            }
            return View(prenda);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrendaViewModel model)
        {
            try
            {
                await _service.AddPrendaAsync(model);
                TempData["SuccessMessage"] = "Prenda creada exitosamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al crear la prenda: {ex.Message}";
                return View(model);

            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var prenda = await _service.GetPrendaByIdAsync(id);
            if (prenda == null)
            {
                TempData["ErrorMessage"] = "Prenda no encontrada.";
                return RedirectToAction("PageNotFound"); // AGREGAR
            }
            return View(prenda);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PrendaViewModel model)
        {

            var resultadoUpd = await _service.UpdatePrendaAsync(model);

            if (!resultadoUpd)
            {
                TempData["ErrorMessage"] = "Error al actualizar la prenda.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Prenda actualizada exitosamente.";
            return RedirectToAction("Index", "Prenda");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desactivar(int id)
        {
            try
            {
                await _service.DesactivarEstadoPrendaByIdAsync(id);
                TempData["SuccessMessage"] = "Prenda desactivada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al desactivar la prenda: {ex.Message}";
            }
            return RedirectToAction("Index","Prenda");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activar(int id)
        {
            try
            {
                await _service.ActivarEstadoPrendaByIdAsync(id);
                TempData["SuccessMessage"] = "Prenda activada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al activar la prenda: {ex.Message}";
            }
            return RedirectToAction("Index","Prenda");
        }



    }
}
