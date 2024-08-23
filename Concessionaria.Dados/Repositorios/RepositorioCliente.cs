using Concessionarias.Dados.Contexto;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concessionarias.Dados.Repositorios
{
    public sealed class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(SqlContext sqlContext) : base(sqlContext) { }

        public async Task<bool> TuplaUnica(int id, string cpf)
        {
            return !await _currentSet.Where(x=> x.Ativo && x.Id != id).AnyAsync(x=> x.CPF.Equals(cpf));
        }
    }
}
