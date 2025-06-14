using Microsoft.EntityFrameworkCore;
using AT_DWNBD.Models;

namespace AT_DWNBD.Data
{
    public class AT_DWNBDContext : DbContext
    {
        public AT_DWNBDContext(DbContextOptions<AT_DWNBDContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<CidadeDestino> CidadeDestino { get; set; } = default!;
        public DbSet<PaisDestino> PaisDestino { get; set; } = default!;
        public DbSet<PacoteTuristico> PacoteTuristico { get; set; } = default!;
        public DbSet<Reserva> Reserva { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaisDestino>()
                .HasMany(p => p.Cidades) 
                .WithOne(c => c.PaisDestino) 
                .HasForeignKey(c => c.PaisDestinoId) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Cliente>()
                .HasMany(cl => cl.Reservas)
                .WithOne(r => r.Cliente) 
                .HasForeignKey(r => r.ClienteId) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(pt => pt.Reservas) 
                .WithOne(r => r.PacoteTuristico) 
                .HasForeignKey(r => r.PacoteTuristicoId) 
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(pt => pt.CidadesDestino) 
                .WithMany(cd => cd.PacotesTuristicos); 

            base.OnModelCreating(modelBuilder);
        }
    }
}