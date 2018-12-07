using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Services.Interfaces.DTO;

namespace WebApplication2.Mappings.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<API.DTO.BuildingCreateDTO, BuildingCreateDto>()
                .ForMember(dest => dest.OpenedOn, opts => opts.MapFrom(src => src.OpenTime))
                .ForMember(dest => dest.ClosedBy, opts => opts.MapFrom(src => src.CloseTime));
        }
    }
}