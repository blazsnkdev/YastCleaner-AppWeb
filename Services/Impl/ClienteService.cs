using YAST_CLENAER_WEB.Data.UoW;
using YAST_CLENAER_WEB.Models.Entity;
using YAST_CLENAER_WEB.Models.ViewModels;
using YAST_CLENAER_WEB.Services.Interfaces;

namespace YAST_CLENAER_WEB.Services.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> ContarTotalClientesAsync(string? estado)
        {
            var lista = await _unitOfWork.ClienteRepository.GetAllClientesByEstadoActivoAsync();
            return lista.Count();
        }

        public async Task<List<ClienteViewModel>> GetAllClientesPaginaByEstadoAsync(string? estado, int pagina, int tamañoPagina)
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAllClientesByEstadoActivoAsync();

            var clienteViewModels = clientes
                .Skip((pagina - 1) * tamañoPagina)
                .Take(tamañoPagina)
                .Select(c => new ClienteViewModel
            {
                IdCliente = c.IdCliente,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Email = c.Email,
                Direccion = c.Direccion,
                FechaRegistro = c.FechaRegistro,
                EstadoCliente = c.EstadoCliente
            }).ToList();

            return clienteViewModels;
        }





    }
}
