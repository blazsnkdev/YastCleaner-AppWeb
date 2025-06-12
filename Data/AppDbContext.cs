using Microsoft.EntityFrameworkCore;
using YAST_CLENAER_WEB.Models.Entity;

namespace YAST_CLENAER_WEB.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Orden> Ordenes => Set<Orden>();
        public DbSet<DetalleOrden> DetalleOrdenes  => Set<DetalleOrden>();
        public DbSet<Prenda> Prendas => Set<Prenda>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<TipoServicio> TipoServicios => Set<TipoServicio>();
        public DbSet<EstadoOrden> EstadosOrden => Set<EstadoOrden>();




    }
}
