using AutoMapper;
using Domain.Model;
using Services.Interfaces.DTO.Investigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings.Profiles
{
    class InvestigationProfile : Profile
    {
        public InvestigationProfile()
        {
            CreateMap<Investigation, InvestigationInfoDTO>();
        }
    }
}
