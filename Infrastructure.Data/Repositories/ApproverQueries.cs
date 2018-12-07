using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ApproverQueries
    {
        public static string ApproveCommentQuery()
        {
            return $"UPDATE [dbo].[Comments] SET IsApproved = 1, ApproverID = @ApproverId WHERE CommentID = @CommentId;";
        }
    }
}
