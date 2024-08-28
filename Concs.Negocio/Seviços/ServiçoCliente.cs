using AutoMapper;
using Concs.Dominio;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Validações;
using System.Net;
using static StackExchange.Redis.Role;

namespace Concs.Negocio.Seviços
{
    public class ServiçoCliente : Serviço, IServiçoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly ICacheamento _cacheamento;

        public ServiçoCliente(IMapper mapper, IRepositorioCliente repositorioCliente, ICacheamento cacheamento) : base(mapper)
        {
            _repositorioCliente = repositorioCliente;
            _cacheamento = cacheamento;
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

            entidade.CPF = entidade.CPF.Replace(".", "").Replace("-", "");

            var cPFCadastrado = await _repositorioCliente.CPFCadastrado(entidade.CPF);

            if (cPFCadastrado)
            {
                return Erro($"Já existe um cliente com {modelo.CPF} no banco.", HttpStatusCode.Conflict);
            }

            await _repositorioCliente.InsertAsync(entidade);
            await _repositorioCliente.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMCLIENTES);

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
            
            if (!EntityIsValid(new ValidadorDeCliente(), Mapper.Map<Cliente>(modelo)))
                return Erro();

            var entidade = await _repositorioCliente.GetByIdAsync(modelo.ClienteId, true);

            if (entidade is null) return Erro($"Não encontrado: {modelo.ClienteId}", HttpStatusCode.NotFound);

            modelo.CPF = modelo.CPF.Replace(".", "").Replace("-", "");

            var cPFCadastrado = await _repositorioCliente.CPFCadastrado(modelo.ClienteId, modelo.CPF);

            if (cPFCadastrado)
            {
                return Erro($"Já existe um cliente com {modelo.CPF} no banco.", HttpStatusCode.Conflict);
            }

            entidade.Nome = modelo.Nome;
            entidade.CPF = modelo.CPF;
            entidade.Telefone = modelo.Telefone;

            await _repositorioCliente.SaveChangesAsync();
            await _cacheamento.RemoverAsync(Constantes.CHAVELISTAGEMCLIENTES);
            return Successo();
        }
    }
}
