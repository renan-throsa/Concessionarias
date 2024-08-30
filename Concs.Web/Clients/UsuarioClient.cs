using Concs.Dominio.Modelos;
using System.Text.Json;
using System.Text;
using Concs.Web.Serviços;

namespace Concs.Web.Clients
{
    public interface IUsuarioClient
    {
        Task<HttpResponseMessage> Registrar(ModeloRegistroUsuario modeloInserçãoUsuario);
        Task<HttpResponseMessage> Autenticar(ModeloAutencicaçãoUsuario modeloAutencicaçãoUsuario);
    }
    public class UsuarioClient : IUsuarioClient
    {
        private readonly HttpClient _client;
        private const string _CONTROLLER = "/Usuario";

        public UsuarioClient(HttpClient client, IUsuarioServiço serviço)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("Authorization", serviço.ObterToken());
        }

        public async Task<HttpResponseMessage> Autenticar(ModeloAutencicaçãoUsuario modeloAutencicaçãoUsuario)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modeloAutencicaçãoUsuario), Encoding.UTF8, "application/json");
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(nameof(Autenticar)).ToString();
            return await _client.PostAsync(rota, jsonContent);
        }

        public async Task<HttpResponseMessage> Registrar(ModeloRegistroUsuario modeloInserçãoUsuario)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modeloInserçãoUsuario), Encoding.UTF8, "application/json");
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(nameof(Registrar)).ToString();
            return await _client.PostAsync(rota, jsonContent);
        }
    }
}
