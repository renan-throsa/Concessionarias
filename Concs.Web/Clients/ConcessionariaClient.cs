using Concs.Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Concs.App.Clients
{
    public interface IConcessionariaClient
    {
        Task<IEnumerable<ModeloConsultaConcessionária>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoConcessionária modelo);
        Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoConcessionária modelo);
        Task<HttpResponseMessage> Excluir(int id);
    }

    public class ConcessionariaClient : IConcessionariaClient
    {
        private readonly HttpClient _client;
        private const string _CONTROLLER = "/Concessionaria";

        public ConcessionariaClient(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            var bearer = $"Bearer {httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "token").Value}";
            _client.DefaultRequestHeaders.Add("Authorization", bearer);
        }

        public async Task<IEnumerable<ModeloConsultaConcessionária>> Listagem()
        {
            using var response = await _client.GetAsync(_CONTROLLER);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<ModeloConsultaConcessionária>>(result, option);
        }

        public async Task<HttpResponseMessage> Encontrar(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await _client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoConcessionária modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await _client.PostAsync(_CONTROLLER, jsonContent);

        }

        public async Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoConcessionária modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await _client.PutAsync(_CONTROLLER, jsonContent);
        }

        public async Task<HttpResponseMessage> Excluir(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await _client.DeleteAsync(rota);
        }
    }
}
