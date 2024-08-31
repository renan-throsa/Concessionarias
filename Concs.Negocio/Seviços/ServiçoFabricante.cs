using AutoMapper;
using Concs.Dominio;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Validações;
using System.Net;

namespace Concs.Negocio.Seviços
{
    public class ServiçoFabricante : Serviço, IServiçoFabricante
    {
        private readonly IRepositorioFabricante _repositorioFabricante;
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        private readonly ICacheamento _cacheamento;

        public ServiçoFabricante(IMapper mapper, IRepositorioFabricante repositorioFabricante, ICacheamento cacheamento, IRepositorioVeiculo repositorioVeiculo) : base(mapper)
        {
            _repositorioFabricante = repositorioFabricante;
            _cacheamento = cacheamento;
            _repositorioVeiculo = repositorioVeiculo;
        }

        public ModeloResultadoDaOperação FindAll()
        {
            return Successo(Mapper.ProjectTo<ModeloVisualizaçãoFabricante>(_repositorioFabricante.Query()));
        }

        public async Task<ModeloResultadoDaOperação> FindById(int id)
        {
            var entidade = await _repositorioFabricante.GetByIdAsync(id);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            return Successo(Mapper.Map<ModeloVisualizaçãoFabricante>(entidade));
        }

        public async Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoFabricante modelo)
        {
            var entidade = Mapper.Map<Fabricante>(modelo);

            if (!EntityIsValid(new ValidadorDeFabricante(), entidade))
                return Erro();

            var nomeCadastrado = await _repositorioFabricante.NomeCadastrado(entidade.Nome);

            if (nomeCadastrado)
            {
                return Erro($"Já existe um Fabricante com o nome {entidade.Nome} no banco.", HttpStatusCode.Conflict);
            }
            await _repositorioFabricante.InsertAsync(entidade);
            await _repositorioFabricante.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMFABRICANTES);
            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioFabricante.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            var possuiRestriçãoDerelacionamento = await _repositorioVeiculo.veiculoComFabricanteCom(id);

            if (possuiRestriçãoDerelacionamento)
            {
                return Erro($"Fabricante possui vinculo com um veículo ativo. Não é possível excluir.", HttpStatusCode.Conflict);
            }


            entidade.Ativo = false;
            await _repositorioFabricante.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMFABRICANTES);
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoFabricante modelo)
        {

            var entidade = await _repositorioFabricante.GetByIdAsync(modelo.FabricanteId, false);

            if (entidade is null) return Erro($"Não encontrado: {modelo.FabricanteId}", HttpStatusCode.NotFound);

            var paraAtualizar = Mapper.Map<Fabricante>(modelo);

            if (!EntityIsValid(new ValidadorDeFabricante(), paraAtualizar))
                return Erro();

            var nomeCadastrado = await _repositorioFabricante.NomeCadastrado(modelo.FabricanteId, modelo.Nome);

            if (nomeCadastrado)
            {
                return Erro($"Já existe um Fabricante com nome {modelo.Nome} no banco.", HttpStatusCode.Conflict);
            }

            await _repositorioFabricante.UpdateAsync(paraAtualizar);
            await _repositorioFabricante.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMFABRICANTES);
            return Successo();
        }
    }
}
