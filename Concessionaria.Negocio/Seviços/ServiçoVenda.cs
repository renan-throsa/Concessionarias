using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Concessionarias.Negocio.Validações;
using System.Net;

namespace Concessionarias.Negocio.Seviços
{
    public class ServiçoVenda : Serviço, IServiçoVenda
    {
        private readonly IRepositorioVenda _repositorioVenda;
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        public ServiçoVenda(IMapper mapper, IRepositorioVenda repositorioVenda, IRepositorioVeiculo repositorioVeiculo) : base(mapper)
        {
            _repositorioVenda = repositorioVenda;
            _repositorioVeiculo = repositorioVeiculo;
        }

        public ModeloResultadoDaOperação FindAll()
        {
            return Successo(Mapper.ProjectTo<ModeloConsultaVenda>(_repositorioVenda.Query().OrderByDescending(x => x.DataVenda)));
        }

        public async Task<ModeloResultadoDaOperação> FindById(int id)
        {
            var entidade = await _repositorioVenda.GetByIdAsync(id);

            if (entidade is null)
            {
                return Erro($"{nameof(Venda)} com id {id} não encontrado", HttpStatusCode.NotFound);
            }

            return Successo(Mapper.Map<ModeloVisualizaçãoVenda>(entidade));
        }

        public async Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVenda modelo)
        {
            var entidade = Mapper.Map<Venda>(modelo);

            var veiculo = await _repositorioVeiculo.GetByIdAsync(modelo.VeiculoId);


            if (veiculo is null)
                return Erro($"{nameof(veiculo)} com id {modelo.VeiculoId} não encontrado", HttpStatusCode.NotFound);


            if (!EntityIsValid(new ValidadorDeVenda(veiculo.Preco), entidade))
                return Erro();

            if (modelo.ClienteId == 0)
            {
                if (!EntityIsValid(new ValidadorDeCliente(), Mapper.Map<Cliente>(modelo.Cliente)))
                    return Erro();
            }

            entidade.Cliente.CPF = entidade.Cliente.CPF.Replace(".", "").Replace("-", "");
            await _repositorioVenda.InsertAsync(entidade);
            await _repositorioVenda.SaveChangesAsync();

            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioVenda.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            entidade.Ativo = false;
            await _repositorioVenda.SaveChangesAsync();
            return Successo(id);
        }

    }
}
