using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Interfaces.DTO;
using WebApplication1.API.DTO;

namespace WebApplication1.Mappings.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<CommentCreateDTO, CreateCommentDTO>();
        }
    }
}