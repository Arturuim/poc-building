using Domain.Interfaces.Repositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Infrastructure.Data.Infrastructure;

namespace Infrastructure.Data.Repositories
{
    public class CommentsRepository : RepositoryBase, ICommentsRepository
    {
        public CommentsRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void AddComment(Comment comment)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(CommentQueries.AddCommentQuery(), new
                {
                    comment.AuthorId,
                    comment.CommentId,
                    comment.ResourceId,
                    comment.Date,
                    comment.Text,
                    comment.IsApproved,
                    comment.ApproverId
                });

                if (res == 0) { throw new Exception("An error occured."); }
            }
        }

        public List<Comment> GetCommentsById(string id)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return conn.Query<Comment>(CommentQueries.GetCommentsById(), new { CommentId = id })
                    .ToList();
            }
        }

        public List<Comment> GetCommentsById(string id, DateTime upToDate)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return conn.Query<Comment>(CommentQueries.GetCommentsByTimeId(), new { id, Date = upToDate })
                    .ToList();
            }
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
