using Concessionarias.Dados.Configs;
using Concessionarias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Concessionarias.Dados.Contexto
{
    public class SqlContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; init; }
        public DbSet<Concessionaria> Concessionarias { get; init; }
        public DbSet<Fabricante> Fabricantes { get; init; }
        public DbSet<Veiculo> Veiculos { get; init; }
        public DbSet<Venda> Vendas { get; init; }


        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
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
