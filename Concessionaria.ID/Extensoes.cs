
using Concessionaria.Dados.Contexto;
using Concessionaria.Dados.Repositorios;
using Concessionaria.Dominio.Interfaces;
using Concessionaria.ID.Configs;
using Concessionaria.Negocio.Mapeamentos;
using Concessionaria.Negocio.Seviços;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Concessionaria.ID
{
    public static class Extensoes
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            var dataBaseSettings = configuration.GetSection(nameof(SqlConfig)).Get<SqlConfig>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(dataBaseSettings.ConnectionString));

            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioConcessionaria, RepositorioConcessionaria>();
            services.AddScoped<IRepositorioFabricante, RepositorioFabricante>();
            services.AddScoped<IRepositorioVeiculo, RepositorioVeiculo>();
            services.AddScoped<IRepositorioVenda, RepositorioVenda>();

            services.AddScoped<IServiçoCliente, ServiçoCliente>();
            return services;
        }
    }
}
