using Concessionaria.Dominio.Entidades;
using FluentValidation;

namespace Concessionaria.Negocio.Validações
{
    internal sealed class ValidadorDeVenda : AbstractValidator<Venda>
    {
        public ValidadorDeVenda()
        {
            RuleFor(x => x.ConcessionariaId).GreaterThan(0);
            RuleFor(x => x.VeiculoId).GreaterThan(0);
            RuleFor(x => x.ClienteId).GreaterThan(0);
            RuleFor(x => x.DataVenda).LessThanOrEqualTo(DateTime.Today);

        }
    }
}
