using Concs.Dominio.Modelos;
using System.Text;
using System.Text.Json;

namespace Concs.App.Clients
{
    public interface IVeiculoClient
    {
        Task<IEnumerable<ModeloConsultaVeiculo>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoVeiculo modelo);
        Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoVeiculo modelo);
        Task<HttpResponseMessage> Excluir(int id);
    }

    public class VeiculoClient : IVeiculoClient
    {
        private readonly HttpClient _client;
        private const string _CONTROLLER = "/Veiculo";

        public VeiculoClient(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            var bearer = $"Bearer {httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "token").Value}";
            _client.DefaultRequestHeaders.Add("Authorization", bearer);
        }


        public async Task<HttpResponseMessage> Encontrar(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await _client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoVeiculo modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await _client.PostAsync(_CONTROLLER, jsonContent);

        }

        public async Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoVeiculo modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await _client.PutAsync(_CONTROLLER, jsonContent);
        }

        public async Task<IEnumerable<ModeloConsultaVeiculo>> Listagem()
        {
            using var response = await _client.GetAsync(_CONTROLLER);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<ModeloConsultaVeiculo>>(result, option);
        }

        public async Task<HttpResponseMessage> Excluir(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await _client.DeleteAsync(rota);
        }
    }
}
