using AutoMapper;
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
        public ServiçoConcessionária(IMapper mapper, IRepositorioConcessionária repositorioConcessionária) : base(mapper)
        {
            _repositorioConcessionária = repositorioConcessionária;
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

            await _repositorioConcessionária.InsertAsync(entidade);
            await _repositorioConcessionária.SaveChangesAsync();

            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioConcessionária.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            entidade.Ativo = false;
            await _repositorioConcessionária.SaveChangesAsync();
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoConcessionária modelo)
        {

            var entidade = await _repositorioConcessionária.GetByIdAsync(modelo.ConcessionariaId, false);

            if (!EntityIsValid(new ValidadorDeConcessionária(), entidade))
                return Erro();


            if (entidade is null) return Erro($"Não encontrado: {modelo.ConcessionariaId}", HttpStatusCode.NotFound);

            await _repositorioConcessionária.UpdateAsync(Mapper.Map<Concessionaria>(modelo));
            await _repositorioConcessionária.SaveChangesAsync();
            return Successo(modelo.ConcessionariaId);
        }
    }
}
