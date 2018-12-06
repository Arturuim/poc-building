
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Services.Interfaces.DTO;

namespace Services.Interfaces
{
    public interface ICommentsService
    {
        void AddComment(CreateCommentDTO comment);

        List<CommentSimplyDTO> GetCommentsById(string resourceId);
    }
}
