using Concessionarias.Dominio.Entidades;
using FluentValidation;

namespace Concessionarias.Negocio.Validações
{
    internal sealed class ValidadorDeVenda : AbstractValidator<Venda>
    {
        public ValidadorDeVenda(decimal preçoVeiculo)
        {
            RuleFor(x => x.ConcessionariaId).GreaterThan(0);
            RuleFor(x => x.VeiculoId).GreaterThan(0);           
            RuleFor(x => x.PrecoVenda).LessThanOrEqualTo(preçoVeiculo);
            RuleFor(x => x.DataVenda).ExclusiveBetween(DateTime.Today.AddMonths(-1), DateTime.Today);

        }
    }
}
