using Concs.Dominio.Entidades;
using FluentValidation;

namespace Concs.Negocio.Validações
{
    internal sealed class ValidadorDeConcessionária : AbstractValidator<Concessionaria>
    {
        public ValidadorDeConcessionária()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Endereco).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Estado).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Cidade).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CEP).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Telefone).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(100).EmailAddress();
            RuleFor(x => x.CapacidadeMaximaVeiculos).GreaterThan(0);
        }
    }
}
