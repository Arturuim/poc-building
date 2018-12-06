using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using Services.Interfaces.DTO;

namespace Services
{
    public class CommentService : ICommentsService
    {
        private readonly ICommentsRepository _commentRepo;

        public CommentService(ICommentsRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public void AddComment(CreateCommentDTO comment)
        {
            var commentData = Mapper.Map<Comment>(comment);
            commentData.AuthorId = Guid.NewGuid().ToString();
            commentData.ResourceId = Guid.NewGuid().ToString();
            commentData.CommentId = Guid.NewGuid().ToString();
            _commentRepo.AddComment(commentData);
        }

        public List<CommentSimplyDTO> GetCommentsById(string resourceId)
        {
            return _commentRepo.GetCommentsById(resourceId)
                .Select(c => Mapper.Map<CommentSimplyDTO>(c))
                .ToList();
        }
    }
}
