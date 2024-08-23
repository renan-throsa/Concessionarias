using Concessionarias.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionarias.Dominio.Interfaces
{
    public interface IServiçoVenda
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVenda modelo);       

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
