using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Api.Models.Buildings;

namespace Web.Api.Mappings.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<BuildingCreateDTO, Services.Interfaces.DTO.BuildingCreateDto>()
                .ForMember(dest => dest.OwnerId, opts => opts.Ignore());
        }
    }
}