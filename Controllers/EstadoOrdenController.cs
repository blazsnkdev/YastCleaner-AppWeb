using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EstadoOrdenController : Controller
    {

        private readonly IEstadoOrdenService _service;
        public EstadoOrdenController(IEstadoOrdenService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int pagina = 1)
        {

            int tamanioPagina = 5;
            var estadosOrden = await _service.GetAllEstadosOrdenPaginaAsync(pagina, tamanioPagina);
            var totalItems = await _service.ContarTotalEstadosOrdenAsync();
            var viewModel = new PaginacionViewModel<EstadoOrdenViewModel>
            {
                Items = estadosOrden,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)totalItems / tamanioPagina)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var estadoOrden = await _service.GetByIdEstadoOrdenAsync(id);
            if (estadoOrden == null)
            {
                TempData["ErrorMessage"] = "Estado no encontrado.";
                return RedirectToAction("PageNotFound"); // AGREGAR
            }
            return View(estadoOrden);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EstadoOrdenViewModel model)
        {
            try
            {
                await _service.CreateEstadoOrdenAsync(model);
                TempData["SuccessMessage"] = "Estado creado exitosamente.";
                return RedirectToAction("Index", "EstadoOrden");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al crear el estado: {ex.Message}";
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var estadoOrden = await _service.GetByIdEstadoOrdenAsync(id);
            if (estadoOrden == null)
            {
                TempData["ErrorMessage"] = "Estado no encontrado.";
                return RedirectToAction("PageNotFound"); // AGREGAR
            }
            return View(estadoOrden);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EstadoOrdenViewModel model)
        {
            var result = await _service.UpdateEstadoOrdenAsync(model);
            if (result)
            {
                TempData["SuccessMessage"] = "Estado actualizado exitosamente.";
                return RedirectToAction("Index", "EstadoOrden");
            }
            else
            {
                TempData["ErrorMessage"] = "Error al actualizar el estado.";
                return View(model);
            }   
        }







    }
}
