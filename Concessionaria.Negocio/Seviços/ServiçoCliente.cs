using AutoMapper;
using Concessionaria.Dominio.Interfaces;
using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Negocio.Seviços
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
            return Success(Mapper.ProjectTo<ModeloVisualizaçãoCliente>(_repositorioCliente.Query()));
        }

        public Task<ModeloResultadoDaOperação> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoCliente modelo)
        {
            throw new NotImplementedException();
        }

        public Task<ModeloResultadoDaOperação> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoCliente modelo)
        {
            throw new NotImplementedException();
        }
    }
}
