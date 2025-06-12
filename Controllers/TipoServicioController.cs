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
        public async Task<IActionResult> Index(string? filtroEstado)
        {
            var lista = await _service.GetAllTipoServicioAsyncByEstado(filtroEstado);
            return View(lista);
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






    }
}
