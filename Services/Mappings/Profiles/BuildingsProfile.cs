using AutoMapper;
using Domain.Model;
using Services.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<BuildingCreateDto, Building>()
                .ForMember(dest => dest.BuildingId, opts => opts.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Condition, opts => opts.MapFrom(x => Conditions.Under_Approve))
                .ForMember(dest => dest.MetaData, opts => opts.Ignore())
                .ForMember(dest => dest.Comments, opts => opts.Ignore());

            CreateMap<Building, BuildingInfoDTO>();
        }
    }
}
