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

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordenes)
                .HasForeignKey(o => o.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.EstadoOrden)
                .WithMany(e =>e.Ordenes)
                .HasForeignKey(o => o.IdEstadoOrden)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DetalleOrden>(entity =>
            {
                
                entity.HasOne(d => d.Orden)
                      .WithMany(o => o.DetallesOrden)
                      .HasForeignKey(d => d.IdOrden)
                      .OnDelete(DeleteBehavior.Cascade);

                
                entity.HasOne(d => d.TipoServicio)
                      .WithMany(t => t.DetallesOrden)
                      .HasForeignKey(d => d.IdTipoServicio)
                      .OnDelete(DeleteBehavior.Restrict);

                
                entity.HasOne(d => d.Prenda)
                      .WithMany(p=>p.DetallesOrden) 
                      .HasForeignKey(d => d.IdPrenda)
                      .OnDelete(DeleteBehavior.SetNull);
            });
        }




        public DbSet<Orden> Ordenes => Set<Orden>();
        public DbSet<DetalleOrden> DetalleOrdenes  => Set<DetalleOrden>();
        public DbSet<Prenda> Prendas => Set<Prenda>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<TipoServicio> TipoServicios => Set<TipoServicio>();
        public DbSet<EstadoOrden> EstadosOrden => Set<EstadoOrden>();




    }
}
