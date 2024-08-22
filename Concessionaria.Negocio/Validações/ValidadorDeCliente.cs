using Concessionaria.Dominio.Entidades;
using FluentValidation;

namespace Concessionaria.Negocio.Validações
{
    internal sealed class ValidadorDeCliente: AbstractValidator<Cliente>
    {
        public ValidadorDeCliente()
        {
            
        }
    }
}
