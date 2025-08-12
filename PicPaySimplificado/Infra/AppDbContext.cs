using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Models;
using PicPaySimplificado.Models.Entities;

namespace PicPaySimplificado.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<TransacaoEntity> Transacoes { get; set; }
        public DbSet<CarteiraEntity> Carteiras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PicPaySimplificado.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de enum para string
            modelBuilder.Entity<TransacaoEntity>()
                .Property(t => t.TipoTransacao)
                .HasConversion<string>();

            modelBuilder.Entity<CarteiraEntity>()
                .Property(c => c.UsuarioTypeEntityType)
                .HasConversion<string>();

            // Configuração dos relacionamentos (pagador e recebedor)
            modelBuilder.Entity<TransacaoEntity>()
                .HasOne<CarteiraEntity>()
                .WithMany()
                .HasForeignKey(t => t.IdPagador)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransacaoEntity>()
                .HasOne<CarteiraEntity>()
                .WithMany()
                .HasForeignKey(t => t.IdRecebedor)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}