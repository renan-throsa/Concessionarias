using Concessionarias.Dominio.Modelos;
using System.Text;
using System.Text.Json;

namespace Concessionarias.IU.Clientes
{
    public interface IVeiculoClient
    {
        Task<IEnumerable<ModeloConsultaVeiculo>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoVeiculo modelo);
        Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoVeiculo modelo);
    }

    public class VeiculoClient : IVeiculoClient
    {
        private readonly HttpClient client;
        private const string _CONTROLLER = "/Veiculo";

        public VeiculoClient(HttpClient client)
        {
            this.client = client;
        }


        public async Task<HttpResponseMessage> Encontrar(int id)
        {
            var rota = new StringBuilder(_CONTROLLER).Append("/").Append(id).ToString();
            return await client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoVeiculo modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PostAsync(_CONTROLLER, jsonContent);

        }

        public async Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoVeiculo modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PutAsync(_CONTROLLER, jsonContent);
        }

        public async Task<IEnumerable<ModeloConsultaVeiculo>> Listagem()
        {
            using var response = await client.GetAsync(_CONTROLLER);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IEnumerable<ModeloConsultaVeiculo>>(result, option);
        }
    }
}
