
using Concessionarias.Dados.Contexto;
using Concessionarias.Dados.Repositorios;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.ID.Configs;
using Concessionarias.Negocio.Mapeamentos;
using Concessionarias.Negocio.Seviços;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Concessionarias.ID
{
    public static class Extensoes
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            var dataBaseSettings = configuration.GetSection(nameof(SqlConfig)).Get<SqlConfig>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(dataBaseSettings.ConnectionString));

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
    }
}
