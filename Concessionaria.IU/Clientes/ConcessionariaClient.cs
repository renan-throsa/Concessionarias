using Concessionarias.Dominio.Modelos;
using System.Text;
using System.Text.Json;

namespace Concessionarias.IU.Clientes
{
    public interface IConcessionariaClient
    {
        Task<IEnumerable<ModeloConsultaConcessionária>> Listagem();
        Task<HttpResponseMessage> Encontrar(int id);
        Task<HttpResponseMessage> Inserir(ModeloInserçãoConcessionária modelo);
        Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoConcessionária modelo);
    }

    public class ConcessionariaClient : IConcessionariaClient
    {
        private readonly HttpClient client;
        private const string _CONTROLLER = "/Concessionaria";

        public ConcessionariaClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<ModeloConsultaConcessionária>> Listagem()
        {
            using var response = await client.GetAsync(_CONTROLLER);

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
            return await client.GetAsync(rota);
        }

        public async Task<HttpResponseMessage> Inserir(ModeloInserçãoConcessionária modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PostAsync(_CONTROLLER, jsonContent);

        }

        public async Task<HttpResponseMessage> Atualizar(ModeloAtualizaçãoConcessionária modelo)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json");

            return await client.PutAsync(_CONTROLLER, jsonContent);
        }
    }
}
