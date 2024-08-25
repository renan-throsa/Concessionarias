using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Validações;
using System.Net;

namespace Concs.Negocio.Seviços
{
    public class ServiçoCliente : Serviço, IServiçoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        public ServiçoCliente(IMapper mapper, IRepositorioCliente repositorioCliente) : base(mapper)
        {
            _repositorioCliente = repositorioCliente;
        }

        public ModeloResultadoDaOperação FindAll()
        {
            return Successo(Mapper.ProjectTo<ModeloVisualizaçãoCliente>(_repositorioCliente.Query()));
        }

        public async Task<ModeloResultadoDaOperação> FindById(int id)
        {
            var entidade = await _repositorioCliente.GetByIdAsync(id);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            return Successo(Mapper.Map<ModeloVisualizaçãoCliente>(entidade));
        }

        public async Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoCliente modelo)
        {
            var entidade = Mapper.Map<Cliente>(modelo);

            if (!EntityIsValid(new ValidadorDeCliente(), entidade))
                return Erro();

            await _repositorioCliente.InsertAsync(entidade);
            await _repositorioCliente.SaveChangesAsync();
            return Successo(entidade.Id);
        }

        public async Task<ModeloResultadoDaOperação> Remove(int id)
        {
            var entidade = await _repositorioCliente.GetByIdAsync(id, true);

            if (entidade is null)
            {
                return Erro($"Não encontrado: {id}", HttpStatusCode.NotFound);
            }

            entidade.Ativo = false;
            await _repositorioCliente.SaveChangesAsync();
            return Successo(id);
        }

        public async Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoCliente modelo)
        {
            if (!await _repositorioCliente.TuplaUnica(modelo.ClienteId, modelo.CPF))
            {
                return Erro($"Cpf {modelo.CPF} já cadastrado", HttpStatusCode.NotFound);
            }

            var entidade = await _repositorioCliente.GetByIdAsync(modelo.ClienteId, true);

            if (!EntityIsValid(new ValidadorDeCliente(), entidade))
                return Erro();


            if (entidade is null) return Erro($"Não encontrado: {modelo.ClienteId}", HttpStatusCode.NotFound);

            entidade.Nome = modelo.Nome;
            entidade.CPF = modelo.CPF;
            entidade.Telefone = modelo.CPF;

            await _repositorioCliente.SaveChangesAsync();
            return Successo();
        }
    }
}
