using Concessionarias.Dominio.Modelos;
using System.Text.Json;

namespace Concessionarias.IU.Clients
{
    public interface IClienteClient
    {
        Task<IEnumerable<ModeloVisualizaçãoCliente>> Listagem();
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
    }
}
