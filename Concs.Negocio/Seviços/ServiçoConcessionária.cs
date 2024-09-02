using AutoMapper;
using Concs.Dominio;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Validações;
using System.Net;

namespace Concs.Negocio.Seviços
{

    public class ServiçoConcessionária : Serviço, IServiçoConcessionária
    {
        private readonly IRepositorioConcessionária _repositorioConcessionária;
        private readonly IRepositorioVenda _repositorioVenda;
        private readonly ICacheamento _cacheamento;

        public ServiçoConcessionária(IMapper mapper, IRepositorioConcessionária repositorioConcessionária, IRepositorioVenda repositorioVenda, ICacheamento cacheamento) : base(mapper)
        {
            _repositorioConcessionária = repositorioConcessionária;
            _repositorioVenda = repositorioVenda;
            _cacheamento = cacheamento;
        }

        public ModeloResultadoDaOperação FindAll()
        {
            return Successo(Mapper.ProjectTo<ModeloConsultaConcessionária>(_repositorioConcessionária.Query()));
        }

        public async Task<ModeloResultadoDaOperação> FindById(int id)
        {
            var entidade = await _repositorioConcessionária.GetByIdAsync(id);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            return Successo(Mapper.Map<ModeloVisualizaçãoConcessionária>(entidade));
        }

        public async Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoConcessionária modelo)
        {
            var entidade = Mapper.Map<Concessionaria>(modelo);

            if (!EntityIsValid(new ValidadorDeConcessionária(), entidade))
                return Erro();

            var nomeCadastrado = await _repositorioConcessionária.NomeCadastrado(entidade.Nome);

            if (nomeCadastrado)
            {
                return Erro($"Já existe um Concessionária com o nome {entidade.Nome} no banco.", HttpStatusCode.Conflict);
            }

            await _repositorioConcessionária.InsertAsync(entidade);
            await _repositorioConcessionária.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMCONCESSIONARIAS);
            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioConcessionária.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            var possuiRestriçãoDerelacionamento = await _repositorioVenda.vendaComConcessionária(id);

            if (possuiRestriçãoDerelacionamento)
            {
                return Erro($"Concessionária possui vinculo com uma venda ativa. Não é possível excluir.", HttpStatusCode.Conflict);
            }

            entidade.Ativo = false;
            await _repositorioConcessionária.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMCONCESSIONARIAS);
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoConcessionária modelo)
        {

            var entidade = await _repositorioConcessionária.GetByIdAsync(modelo.ConcessionariaId, false);

            if (entidade is null) return Erro($"Não encontrado: {modelo.ConcessionariaId}", HttpStatusCode.NotFound);

            var paraAtualizar = Mapper.Map<Concessionaria>(modelo);

            if (!EntityIsValid(new ValidadorDeConcessionária(), paraAtualizar))
                return Erro();

            var nomeCadastrado = await _repositorioConcessionária.NomeCadastrado(paraAtualizar.Id, paraAtualizar.Nome);

            if (nomeCadastrado)
            {
                return Erro($"Já existe um Concessionária com o nome {paraAtualizar.Nome} no banco.", HttpStatusCode.Conflict);
            }

            await _repositorioConcessionária.UpdateAsync(paraAtualizar);
            await _repositorioConcessionária.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMCONCESSIONARIAS);

            return Successo(modelo.ConcessionariaId);
        }
    }
}
