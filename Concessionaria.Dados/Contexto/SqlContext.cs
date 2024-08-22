using Concessionaria.Dados.Configs;
using Concessionaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Dados.Contexto
{
    public class SqlContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; init; }
        public DbSet<Dominio.Entidades.Concessionaria> Concessionarias { get; init; }
        public DbSet<Fabricante> Fabricantes { get; init; }
        public DbSet<Veiculo> Veiculos { get; init; }
        public DbSet<Venda> Vendas { get; init; }


        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ConcessionariaConfig());
            modelBuilder.ApplyConfiguration(new FabricanteConfig());
            modelBuilder.ApplyConfiguration(new TipoVeiculoConfig());
            modelBuilder.ApplyConfiguration(new VeiculoConfig());
            modelBuilder.ApplyConfiguration(new VendaConfig());

        }
    }
}
