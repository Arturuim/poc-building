using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CommentQueries
    {
        public static string AddCommentQuery()
        {
            return $@"INSERT INTO [dbo].[Comments](CommentId, ResourceId, AuthorId, Text, Date, IsApproved, ApproverId) 
                      VALUES(@CommentId, @ResourceId, @AuthorId, @Text, @Date, @IsApproved, @ApproverId)";
        }

        public static string GetCommentsById()
        {
            return $"SELECT * FROM [dbo].[Comments] WHERE CommentId=@CommentId ";
        }

        public static string GetCommentsByTimeId()
        {
            return $"SELECT * FROM [dbo].[Comments] WHERE Id=@Id AND Date >= Convert(datetime, @date)";
        }
    }
}
