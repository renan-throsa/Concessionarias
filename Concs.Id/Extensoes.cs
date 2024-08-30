
using Concs.Dados.Configs;
using Concs.Dados.Contexto;
using Concs.Dados.Repositorios;
using Concs.Dominio.Interfaces;
using Concs.Negocio.Configs;
using Concs.Negocio.Mapeamentos;
using Concs.Negocio.Seviços;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Concs.Id
{
    public static class Extensoes
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            var sqlConfig = configuration.GetSection(nameof(SqlConfig)).Get<SqlConfig>();
            var webConfig = configuration.GetSection(nameof(WebConfig)).Get<WebConfig>();
            var segConfig = configuration.GetSection(nameof(SegConfig)).Get<SegConfig>();

            services.Configure<SegConfig>(configuration.GetSection(nameof(SegConfig)));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfiles)));


            services.AddDbContext<SqlContext>(options => options.UseSqlServer(sqlConfig.ConnectionString));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<SqlContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(segConfig.Segredo)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,                    
                    ValidAudience = segConfig.Audiencia,
                    ValidIssuer = segConfig.Emissor
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(webConfig.Policy,
                                  policy =>
                                  {
                                      policy.WithOrigins(webConfig.Origin);
                                  });
            });

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
            services.AddScoped<IServiçoUsuario, ServiçoUsuario>();

            services.AddScoped<ICacheamento, ServiçoCacheamento>();

            services.AddStackExchangeRedisCache(x =>
            {
                x.Configuration = webConfig.CacheHost;
            });

            return services;
        }

        public static IServiceCollection AddWebApiDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });


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
