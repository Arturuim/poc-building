using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface ICommentsRepository
    {
        List<Comment> GetCommentsById(string id);

        List<Comment> GetCommentsById(string id, DateTime upToDate);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment);
    }
}
