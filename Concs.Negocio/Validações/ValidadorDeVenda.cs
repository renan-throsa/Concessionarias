using Concs.Dominio.Entidades;
using DocumentValidator;
using FluentValidation;

namespace Concs.Negocio.Validações
{
    internal sealed class ValidadorDeVenda : AbstractValidator<Venda>
    {
        public ValidadorDeVenda(decimal preçoVeiculo)
        {
            RuleFor(x => x.ConcessionariaId).GreaterThan(0);
            RuleFor(x => x.VeiculoId).GreaterThan(0);
            RuleFor(x => x.PrecoVenda).ExclusiveBetween(0, preçoVeiculo);
            RuleFor(x => x.DataVenda).InclusiveBetween(DateTime.Today.AddMonths(-1), DateTime.Today);

            When(x => x.ClienteId == 0, () =>
            {
                RuleFor(x => x.Cliente.Nome).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Cliente.CPF).NotEmpty().Must(x => x is not null && CpfValidation.Validate(x));
                RuleFor(x => x.Cliente.Telefone).NotEmpty().Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$");
            });
        }
    }
}
