using AutoMapper;
using Concs.Dominio;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Validações;
using System.Net;

namespace Concs.Negocio.Seviços
{
    public class ServiçoVeiculo : Serviço, IServiçoVeiculo
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        private readonly IRepositorioVenda _repositorioVenda;
        private readonly ICacheamento _cacheamento;

        public ServiçoVeiculo(IMapper mapper, IRepositorioVeiculo repositorioVeiculo, IRepositorioVenda repositorioVenda, ICacheamento cacheamento) : base(mapper)
        {
            _repositorioVeiculo = repositorioVeiculo;
            _cacheamento = cacheamento;
            _repositorioVenda = repositorioVenda;
        }

        public ModeloResultadoDaOperação FindAll()
        {
            return Successo(Mapper.ProjectTo<ModeloConsultaVeiculo>(_repositorioVeiculo.Query()));
        }

        public async Task<ModeloResultadoDaOperação> FindById(int id)
        {
            var entidade = await _repositorioVeiculo.GetByIdAsync(id);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            return Successo(Mapper.Map<ModeloVisualizaçãoVeiculo>(entidade));
        }

        public async Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVeiculo modelo)
        {
            var entidade = Mapper.Map<Veiculo>(modelo);

            if (!EntityIsValid(new ValidadorDeVeiculo(), entidade))
                return Erro();

            await _repositorioVeiculo.InsertAsync(entidade);
            await _repositorioVeiculo.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMVEICULOS);
            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioVeiculo.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Veículo com id {id} não encontrado", HttpStatusCode.NotFound);
            }

            var possuiRestriçãoDerelacionamento = await _repositorioVenda.vendaComVeiculo(id);

            if (possuiRestriçãoDerelacionamento)
            {
                return Erro($"Veículo possui vinculo com uma venda ativa. Não é possível excluir.", HttpStatusCode.Conflict);
            }

            entidade.Ativo = false;
            await _repositorioVeiculo.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMVEICULOS);
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoVeiculo modelo)
        {

            var entidade = await _repositorioVeiculo.GetByIdAsync(modelo.VeiculoId, false);

            if (entidade is null)
                return Erro($"Não encontrado: {modelo.VeiculoId}", HttpStatusCode.NotFound);

            var paraAtualizar = Mapper.Map<Veiculo>(modelo);

            if (!EntityIsValid(new ValidadorDeVeiculo(), paraAtualizar))
                return Erro();


            await _repositorioVeiculo.UpdateAsync(paraAtualizar);
            await _repositorioVeiculo.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMVEICULOS);
            return Successo();
        }
    }
}
