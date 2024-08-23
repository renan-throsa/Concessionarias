using Concessionarias.Dominio.Entidades;
using FluentValidation;

namespace Concessionarias.Negocio.Validações
{
    internal sealed class ValidadorDeCliente : AbstractValidator<Cliente>
    {
        public ValidadorDeCliente()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CPF).NotEmpty().MaximumLength(11);
            RuleFor(x => x.Telefone).NotEmpty().MaximumLength(15);
        }
    }
}
