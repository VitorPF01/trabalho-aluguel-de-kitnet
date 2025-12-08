using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções do DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        // DbSet para os modelos User e Kitnet
        public DbSet<User> Users { get; set; }
        public DbSet<Kitnet> Kitnets { get; set; }

        // Configurações do modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a coluna Preco para usar o tipo decimal com precisão e escala
            modelBuilder.Entity<Kitnet>(entity =>
            {
                entity.Property(k => k.Preco)
                      .HasColumnType("decimal(18,2)"); // Define precisão e escala para a coluna Preco
            });
        }
    }
}
