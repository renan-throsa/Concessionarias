
using Concs.Dados.Contexto;
using Concs.Dados.Repositorios;
using Concs.Dominio.Interfaces;
using Concs.Id.Configs;
using Concs.Negocio.Mapeamentos;
using Concs.Negocio.Seviços;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Concs.Id
{
    public static class Extensoes
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration, bool IsProduction)
        {

            var sqlConfig = configuration.GetSection(nameof(SqlConfig)).Get<SqlConfig>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));

            if (IsProduction)
            {
                //TODO : bug quando em produção.
                services.AddDbContext<SqlContext>(options => options.UseSqlServer("Server=docker-sql;Database=CONCS_PROD;User Id=sa;Password=MyPass@word;TrustServerCertificate=True;"));
            }
            else
            {
                services.AddDbContext<SqlContext>(options => options.UseSqlServer(sqlConfig.ConnectionString));
            }
            

            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioConcessionária, RepositorioConcessionária>();
            services.AddScoped<IRepositorioFabricante, RepositorioFabricante>();
            services.AddScoped<IRepositorioVeiculo, RepositorioVeiculo>();
            services.AddScoped<IRepositorioVenda, RepositorioVenda>();

            services.AddScoped<IServiçoCliente, ServiçoCliente>();
            services.AddScoped<IServiçoVeiculo, ServiçoVeiculo>();
            services.AddScoped<IServiçoFabricante, ServiçoFabricante>();
            services.AddScoped<IServiçoConcessionária, ServiçoConcessionária>();
            services.AddScoped<IServiçoVenda, ServiçoVenda>();
            return services;
        }

        public static async Task AddMigrationsAsync(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<SqlContext>())
                {                    
                    await context.Database.MigrateAsync();
                }
            }
        }
    }


}
