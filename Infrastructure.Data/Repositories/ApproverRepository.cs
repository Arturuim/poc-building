using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Infrastructure;

namespace Infrastructure.Data.Repositories
{
    public class ApproverRepository : RepositoryBase, IApproverRepository
    {
        public ApproverRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void ApproveComment(string commentId, string approverId)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(ApproverQueries.ApproveCommentQuery(), new {commentId, approverId});

                if (res == 0)
                {
                    throw new Exception("An error has occured."); 
                }
            }
        }
    }
}
