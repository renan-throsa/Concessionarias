using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace Concs.Negocio.Seviços
{
    public abstract class Serviço
    {
        protected readonly IMapper Mapper;
        private ValidationResult _validationResult;

        protected Serviço(IMapper mapper) => Mapper = mapper;

        protected ModeloResultadoDaOperação Erro() => new ModeloResultadoDaOperação(_validationResult);

        protected ModeloResultadoDaOperação Erro(HttpStatusCode statusCode) => new ModeloResultadoDaOperação(_validationResult, statusCode);

        protected ModeloResultadoDaOperação Erro(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            return new ModeloResultadoDaOperação(new ValidationResult(failures), statusCode);
        }

        protected ModeloResultadoDaOperação Successo(object obj = null) => new ModeloResultadoDaOperação(obj);

        protected ModeloResultadoDaOperação Successo(long id) => new ModeloResultadoDaOperação(id);


        protected bool EntityIsValid<TV, TE>(TV validator, TE entity, string[] ruleSets = null) where TV : AbstractValidator<TE> where TE : EntidadeBase
        {
            ValidationResult result;
            if (ruleSets == null)
            {
                result = validator.Validate(entity);
            }
            else
            {
                result = validator.Validate(entity, options => options.IncludeRuleSets(ruleSets));
            }

            if (result.IsValid) return true;

            _validationResult = result;
            return false;
        }

        protected bool EntityIsValid<TV, TE>(TV validator, IEnumerable<TE> entities) where TV : AbstractValidator<TE> where TE : EntidadeBase
        {
            foreach (var item in entities)
            {
                var result = validator.Validate(item);
                if (!result.IsValid)
                {
                    _validationResult = result;
                    return false;
                }
            }

            return true;
        }
    }
}
