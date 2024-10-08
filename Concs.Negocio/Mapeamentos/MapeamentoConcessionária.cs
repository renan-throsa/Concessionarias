﻿using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;

namespace Concs.Negocio.Mapeamentos
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

            CreateMap<Concessionaria, ModeloAtualizaçãoConcessionária>().ForMember(dest => dest.ConcessionariaId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
