using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Concessionarias.Negocio.Validações;
using System.Net;

namespace Concessionarias.Negocio.Seviços
{
    public class ServiçoFabricante : Serviço, IServiçoFabricante
    {
        private readonly IRepositorioFabricante _repositorioFabricante;
        public ServiçoFabricante(IMapper mapper, IRepositorioFabricante repositorioFabricante) : base(mapper)
        {
            _repositorioFabricante = repositorioFabricante;
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

            await _repositorioFabricante.InsertAsync(entidade);
            await _repositorioFabricante.SaveChangesAsync();

            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioFabricante.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            entidade.Ativo = false;
            await _repositorioFabricante.SaveChangesAsync();
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoFabricante modelo)
        {            

            var entidade = await _repositorioFabricante.GetByIdAsync(modelo.FabricanteId, true);

            if (!EntityIsValid(new ValidadorDeFabricante(), entidade))
                return Erro();


            if (entidade is null) return Erro($"Não encontrado: {modelo.FabricanteId}", HttpStatusCode.NotFound);

            entidade.Nome = modelo.Nome;
            entidade.PaisOrigem = modelo.PaisOrigem;
            entidade.AnoFundacao = modelo.AnoFundacao;
            entidade.Website = modelo.Website;

            await _repositorioFabricante.SaveChangesAsync();
            return Successo();
        }
    }
}
