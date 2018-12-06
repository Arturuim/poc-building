using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces.DTO;
using Domain.Model;

namespace Services.Mapping.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<Comment, CommentSimplyDTO>();
        }
    }
}
