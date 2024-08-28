using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;

namespace Concs.Negocio.Mapeamentos
{
    public class MapeamentoCliente : Profile
    {
        public MapeamentoCliente()
        {
            CreateMap<Cliente, ModeloVisualizaçãoCliente>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Cliente, ModeloInserçãoCliente>()
                .ReverseMap();


            CreateMap<Cliente, ModeloAtualizaçãoCliente>()
                .ReverseMap();
        }
    }
}
