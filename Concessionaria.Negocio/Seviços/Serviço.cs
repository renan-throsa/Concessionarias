using AutoMapper;
using Concessionaria.Dominio.Modelos;
using FluentValidation.Results;

namespace Concessionaria.Negocio.Seviços
{
    public abstract class Serviço
    {
        protected readonly IMapper Mapper;
        private ValidationResult _validationResult;

        protected Serviço(IMapper mapper) => Mapper = mapper;


        protected ModeloResultadoDaOperação Success(object obj = null) => new ModeloResultadoDaOperação(obj);

        protected ModeloResultadoDaOperação Success(long id) => new ModeloResultadoDaOperação(id);
    }
}
