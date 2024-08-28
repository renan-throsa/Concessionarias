using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Repositorios
{
    public class RepositorioConcessionária : Repositorio<Concessionaria>, IRepositorioConcessionária
    {
        public RepositorioConcessionária(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public async Task<bool> NomeCadastrado(string cpf)
        {
            return await _currentSet.Where(x => x.Ativo).AnyAsync(x => x.Nome.Equals(cpf));
        }

        public async Task<bool> NomeCadastrado(int id, string cpf)
        {
            return await _currentSet.Where(x => x.Ativo && x.Id != id).AnyAsync(x => x.Nome.Equals(cpf));
        }
    }
}
