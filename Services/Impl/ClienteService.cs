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

        public async Task AddClienteAsync(ClienteViewModel model)
        {
            model.FechaRegistro = DateTime.Now;
            model.EstadoCliente = "Activo";
            var cliente = new Cliente
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Telefono = model.Telefono,
                Email = model.Email,
                Direccion = model.Direccion,
                FechaRegistro = model.FechaRegistro,
                EstadoCliente = model.EstadoCliente

            };
            await _unitOfWork.Cliente.AddAsync(cliente);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> ContarTotalClientesAsync(string? estado)
        {
            var lista = await _unitOfWork.ClienteRepository.GetAllClientesByEstadoActivoAsync();
            return lista.Count();
        }

        public async Task DesactivarEstadoClienteByIdAsync(int id)
        {
            await _unitOfWork.ClienteRepository.UpdateEstadoDesactivadoAsync(id);
            await _unitOfWork.SaveChangesAsync();
            
        }

        public async Task<List<ClienteViewModel>> GetAllClientesPaginaByEstadoAsync(string? estado, int pagina, int tamanioPagina)
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAllClientesByEstadoActivoAsync();

            var clienteViewModels = clientes
                .Skip((pagina - 1) * tamanioPagina)
                .Take(tamanioPagina)
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

        public async Task<ClienteViewModel?> GetClienteByIdAsync(int id)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(id);
            if (cliente == null) return null;
            return new ClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Direccion = cliente.Direccion,
                FechaRegistro = cliente.FechaRegistro,
                EstadoCliente = cliente.EstadoCliente
            };
        }

        public async Task<bool> UpdateClienteAsync(ClienteViewModel model)
        {
            var cliente = await _unitOfWork.Cliente.GetByIdAsync(model.IdCliente);

            if(cliente==null) return false;


            cliente.Nombre = model.Nombre;
            cliente.Apellido = model.Apellido;
            cliente.Telefono = model.Telefono;
            cliente.Email = model.Email;
            cliente.Direccion = model.Direccion;

            _unitOfWork.Cliente.UpdateAsync(cliente);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
