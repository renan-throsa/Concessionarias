using Concs.App.Clients;
using Concs.App.Configs;
using Concs.Web.Clients;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Net.Http.Headers;

namespace Concs.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfigurationSection clientSettingsSection = builder.Configuration.GetSection(nameof(ApiConfigs));
            string address = clientSettingsSection.Get<ApiConfigs>().AppParaApiEndereco;

            builder.Services.Configure<ApiConfigs>(clientSettingsSection);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = "/Usuario/Autenticar";
                            });

            
            builder.Services.AddHttpClient<IFabricanteClient, FabricanteClient>((HttpClient client) =>
            {                
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");              
                
            });

            builder.Services.AddHttpClient<IVeiculoClient, VeiculoClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");
            });

            builder.Services.AddHttpClient<IConcessionariaClient, ConcessionariaClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");
            });

            builder.Services.AddHttpClient<IVendaClient, VendaClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");
            });

            builder.Services.AddHttpClient<IClienteClient, ClienteClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");
            });

            builder.Services.AddHttpClient<IUsuarioClient, UsuarioClient>((HttpClient client) =>
            {
                client.BaseAddress = new Uri(address);
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "text/plain");
            });
            

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}