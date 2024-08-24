using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Negocio.Mapeamentos
{
    public class MapeamentoFabricante : Profile
    {
        public MapeamentoFabricante()
        {
            CreateMap<Fabricante, ModeloVisualizaçãoFabricante>()
                .ForMember(dest => dest.FabricanteId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Fabricante, ModeloInserçãoFabricante>().ReverseMap();
            CreateMap<Fabricante, ModeloAtualizaçãoFabricante>().ReverseMap();
        }
    }
}
