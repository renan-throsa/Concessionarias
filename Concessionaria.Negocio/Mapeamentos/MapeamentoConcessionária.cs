using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Negocio.Mapeamentos
{
    public class MapeamentoConcessionária : Profile
    {
        public MapeamentoConcessionária()
        {
            CreateMap<Concessionaria, ModeloVisualizaçãoConcessionária>()
                .ForMember(dest => dest.ConcessionariaId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Concessionaria, ModeloConsultaConcessionária>()
                .ForMember(dest => dest.ConcessionariaId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Concessionaria, ModeloInserçãoConcessionária>().ReverseMap();
            CreateMap<Concessionaria, ModeloAtualizaçãoConcessionária>().ReverseMap();
        }
    }
}
