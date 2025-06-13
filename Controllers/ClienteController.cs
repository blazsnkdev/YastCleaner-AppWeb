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
    }
}
