using Concs.App.Clients;
using Concs.App.Configs;
using Microsoft.Net.Http.Headers;

namespace Concs.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            IConfigurationSection clientSettingsSection = builder.Configuration.GetSection(nameof(ApiConfigs));
            string address = clientSettingsSection.Get<ApiConfigs>().Endereco;

            builder.Services.Configure<ApiConfigs>(clientSettingsSection); 

            builder.Services.AddHttpClient<IFabricanteClient, FabricanteClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            builder.Services.AddHttpClient<IVeiculoClient, VeiculoClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            builder.Services.AddHttpClient<IConcessionariaClient, ConcessionariaClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            builder.Services.AddHttpClient<IVendaClient, VendaClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            builder.Services.AddHttpClient<IClienteClient, ClienteClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}