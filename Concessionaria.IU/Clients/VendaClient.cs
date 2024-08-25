using Concessionarias.Dominio.Modelos;
using System.Text;
using System.Text.Json;

namespace Concessionarias.IU.Clients
{
    public interface IVendaClient
    {
        Task<IEnumerable<ModeloConsultaVenda>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoVenda modelo);
    }

    public class VendaClient : IVendaClient
    {
        private readonly HttpClient client;
        private const string _CONTROLLER = "/Venda";

        public VendaClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<HttpResponseMessage> Encontrar(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoVenda modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PostAsync(_CONTROLLER, jsonContent);
        }

        public async Task<IEnumerable<ModeloConsultaVenda>> Listagem()
        {
            using var response = await client.GetAsync(_CONTROLLER);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<ModeloConsultaVenda>>(result, option);
        }
    }
}
