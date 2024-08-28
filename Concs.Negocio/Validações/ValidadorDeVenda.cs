using Concs.Dominio.Entidades;
using FluentValidation;

namespace Concs.Negocio.Validações
{
    internal sealed class ValidadorDeVenda : AbstractValidator<Venda>
    {
        public ValidadorDeVenda(decimal preçoVeiculo)
        {
            RuleFor(x => x.ConcessionariaId).GreaterThan(0);
            RuleFor(x => x.VeiculoId).GreaterThan(0);
            RuleFor(x => x.PrecoVenda).ExclusiveBetween(0,preçoVeiculo);
            RuleFor(x => x.DataVenda).InclusiveBetween(DateTime.Today.AddMonths(-1), DateTime.Today);

        }
    }
}
