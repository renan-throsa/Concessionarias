using FluentValidation;

namespace Concessionaria.Negocio.Validações
{
    internal sealed class ValidadorDeConcessionaria : AbstractValidator<Dominio.Entidades.Concessionaria>
    {
        public ValidadorDeConcessionaria()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Estado).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Cidade).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CEP).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Telefone).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
        }
    }
}
