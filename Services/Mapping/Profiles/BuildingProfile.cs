using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Model;
using Services.Interfaces.DTO;

namespace Services.Mapping.Profiles
{
    class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingCreateDto, Building>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.MetaData, opts => opts.Ignore())
                .ForMember(dest => dest.Comments, opts => opts.Ignore());

            CreateMap<Building, BuildingInfoDTO>();
        }
    }
}
