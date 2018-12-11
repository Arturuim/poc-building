using AutoMapper;
using Domain.Model;
using Services.Interfaces.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings.Profiles
{
    class DealProfile : Profile
    {
        public DealProfile()
        {
            CreateMap<CreateDealDTO, Deal>()
                .ForMember(dest => dest.DealId, opts => opts.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(c => DealStatus.InProgres));
        }
    }
}
