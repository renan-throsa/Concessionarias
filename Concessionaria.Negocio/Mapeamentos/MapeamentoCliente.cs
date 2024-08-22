using AutoMapper;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Negocio.Mapeamentos
{
    internal class MapeamentoCliente: Profile
    {
        public MapeamentoCliente()
        {
            CreateMap<Cliente, ModeloVisualizaçãoCliente>().ReverseMap();
            CreateMap<Cliente, ModeloInserçãoCliente>().ReverseMap();
        }
    }
}
