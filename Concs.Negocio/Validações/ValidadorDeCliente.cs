using Concs.Dominio.Entidades;
using FluentValidation;
using DocumentValidator;

namespace Concs.Negocio.Validações
{
    internal sealed class ValidadorDeCliente : AbstractValidator<Cliente>
    {
        public ValidadorDeCliente()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CPF).NotEmpty().Must(x => x is not null && CpfValidation.Validate(x));
            RuleFor(x => x.Telefone).NotEmpty().MaximumLength(15);
        }
    }
}
