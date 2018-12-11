using AutoMapper;
using Services.Interfaces.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Api.Models.Buildings;
using Web.Api.Models.Deals;

namespace Web.Api.Mappings.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<BuildingCreateDTO, Services.Interfaces.DTO.BuildingCreateDto>()
                .ForMember(dest => dest.OwnerId, opts => opts.Ignore());

            CreateMap<DealCreateDTO, CreateDealDTO>();

            CreateMap<Services.Interfaces.DTO.BuildingInfoDTO, BuildingInfoDTO>();
        }
    }
}