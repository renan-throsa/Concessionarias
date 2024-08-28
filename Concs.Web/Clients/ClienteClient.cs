using Concs.Dominio.Modelos;
using System.Text;
using System.Text.Json;

namespace Concs.App.Clients
{
    public interface IClienteClient
    {
        Task<IEnumerable<ModeloVisualizaçãoCliente>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoCliente modelo);
        Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoCliente modelo);
    }

    public class ClienteClient : IClienteClient
    {
        private readonly HttpClient client;
        private const string _CONTROLLER = "/Cliente";

        public ClienteClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<ModeloVisualizaçãoCliente>> Listagem()
        {
            using var response = await client.GetAsync(_CONTROLLER);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<ModeloVisualizaçãoCliente>>(result, option);
        }

        public async Task<HttpResponseMessage> Encontrar(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoCliente modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PostAsync(_CONTROLLER, jsonContent);

        }

        public async Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoCliente modelo)
        {

            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PutAsync(_CONTROLLER, jsonContent);
        }
    }
}
