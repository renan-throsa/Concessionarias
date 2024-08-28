using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Repositorios
{
    public sealed class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(SqlContext sqlContext) : base(sqlContext) { }

        public async Task<bool> CPFCadastrado(string cpf)
        {
            return await _currentSet.Where(x => x.Ativo).AnyAsync(x => x.CPF.Equals(cpf));
        }

        public async Task<bool> CPFCadastrado(int id, string cpf)
        {
            return await _currentSet.Where(x=> x.Ativo && x.Id != id).AnyAsync(x=> x.CPF.Equals(cpf));
        }
    }
}
