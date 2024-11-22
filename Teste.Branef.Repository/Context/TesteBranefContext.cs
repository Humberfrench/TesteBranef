using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Teste.Branef.Domain.Entity;

namespace Teste.Branef.Repository.Context
{
    public class TesteBranefContext : DbContext
    {
        public TesteBranefContext()
        {
            
        }
        public TesteBranefContext(DbContextOptions<TesteBranefContext> options)
    : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");

                entity.HasKey(e => e.ClienteId);

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .HasMaxLength(50);

                entity.Property(e => e.Porte)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(150);

                entity.Ignore(e => e.Erros);
                entity.Ignore(e => e.Valid);
            });
        }

        // Configuração da string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

                var connectionString = configuration.GetConnectionString("branefContext");

                //optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
