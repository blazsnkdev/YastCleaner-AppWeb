using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Controllers
{
    [Authorize(Roles ="Admin,Empleado")]
    public class ClienteController : Controller
    {

        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        public IActionResult Index(string? filtroEstado, int pagina = 1)
        {
            int tamañoPagina = 5;
            var clientes = _service.GetAllClientesPaginaByEstadoAsync(filtroEstado, pagina, tamañoPagina).Result;
            var totalItems = _service.ContarTotalClientesAsync(filtroEstado).Result;

            var viewModel = new PaginacionViewModel<ClienteViewModel>
            {
                Items = clientes,
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling((double)totalItems / tamañoPagina),
                FiltroEstado = filtroEstado
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _service.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                TempData["ErrorMessage"] = "Cliente no encontrado.";
                return RedirectToAction("PageNotFound"); // AGREGAR
            }
            return View(cliente);

        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClienteViewModel model)
        {
            try
            {
                await _service.AddClienteAsync(model);
                TempData["SuccessMessage"] = "Cliente creado exitosamente.";
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al crear el cliente: " + ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _service.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                TempData["ErrorMessage"] = "Cliente no encontrado.";
                return RedirectToAction("PageNotFound");// AGREGAR
            }
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClienteViewModel model)
        {
            var resultado = await _service.UpdateClienteAsync(model);
            if (!resultado)
            {
                TempData["ErrorMessage"] = "Error al actualizar el cliente.";
                return View(model);
            }
            TempData["SuccessMessage"] = "Cliente actualizado exitosamente.";
            return RedirectToAction("Index", "Cliente");

        }

        [HttpPost]
        public async Task<IActionResult> Desactivar(int id)
        {
            try{
                await _service.DesactivarEstadoClienteByIdAsync(id);
                TempData["SuccessMessage"] = "Cliente desactivado exitosamente.";
            }
            catch (Exception ex){

                TempData["ErrorMessage"] = "Error al desactivar el cliente: " + ex.Message;
            }
            return RedirectToAction("Index", "Cliente");
        }


        }
}
