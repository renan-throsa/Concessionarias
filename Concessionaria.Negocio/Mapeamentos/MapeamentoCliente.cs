using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Negocio.Mapeamentos
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
        }
    }
}
