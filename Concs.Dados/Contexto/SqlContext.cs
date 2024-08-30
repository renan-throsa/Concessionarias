using Concs.Dados.Configs;
using Concs.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Contexto
{
    public class SqlContext : IdentityDbContext
    {
        public DbSet<Cliente> Clientes { get; init; }
        public DbSet<Concessionaria> Concessionarias { get; init; }
        public DbSet<Fabricante> Fabricantes { get; init; }
        public DbSet<TipoVeiculo> TiposVeiculos { get; init; }
        public DbSet<Veiculo> Veiculos { get; init; }
        public DbSet<Venda> Vendas { get; init; }


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
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ClaimConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
