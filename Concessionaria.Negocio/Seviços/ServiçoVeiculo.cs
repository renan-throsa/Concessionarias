using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Concessionarias.Negocio.Validações;
using System.Net;

namespace Concessionarias.Negocio.Seviços
{
    public class ServiçoVeiculo : Serviço, IServiçoVeiculo
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        public ServiçoVeiculo(IMapper mapper, IRepositorioVeiculo repositorioVeiculo) : base(mapper)
        {
            _repositorioVeiculo = repositorioVeiculo;
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

            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioVeiculo.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            entidade.Ativo = false;
            await _repositorioVeiculo.SaveChangesAsync();
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoVeiculo modelo)
        {

            var entidade = await _repositorioVeiculo.GetByIdAsync(modelo.VeiculoId, true);

            if (entidade is null)
                return Erro($"Não encontrado: {modelo.VeiculoId}", HttpStatusCode.NotFound);

            if (!EntityIsValid(new ValidadorDeVeiculo(), entidade))
                return Erro();

            entidade.FabricanteId = modelo.FabricanteId;
            entidade.TipoVeiculoId = modelo.TipoVeiculoId;
            entidade.Modelo = modelo.Modelo;
            entidade.AnoFabricacao = modelo.AnoFabricacao;
            entidade.Preco = modelo.Preco;
            entidade.Modelo = modelo.Modelo;

            await _repositorioVeiculo.SaveChangesAsync();
            return Successo();
        }
    }
}
