using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;

namespace Concs.Negocio.Mapeamentos
{
    public class MapeamentoFabricante : Profile
    {
        public MapeamentoFabricante()
        {
            CreateMap<Fabricante, ModeloVisualizaçãoFabricante>()
                .ForMember(dest => dest.FabricanteId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Fabricante, ModeloInserçãoFabricante>().ReverseMap();

            CreateMap<Fabricante, ModeloAtualizaçãoFabricante>()
                .ForMember(dest => dest.FabricanteId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
