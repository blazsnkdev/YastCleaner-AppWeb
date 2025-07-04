﻿using YAST_CLENAER_WEB.Data.Interfaces;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data.UoW
{
    public interface IUnitOfWork
    {

        IRepository<TipoServicio> TipoServicio { get; }
        IRepository<Cliente> Cliente { get; }

        IClienteRepository ClienteRepository { get; }
        ITipoServicioRepository TipoServicioRepository { get; }

        Task<int> SaveChangesAsync();

    }
}
