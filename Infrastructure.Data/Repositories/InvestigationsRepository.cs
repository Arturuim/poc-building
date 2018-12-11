using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Infrastructure.Data.Infrastructure;

namespace Infrastructure.Data.Repositories
{
    public class InvestigationsRepository : RepositoryBase, IInvestigationsRepository
    {
        public InvestigationsRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void AddInvestigator(string investigationId, string investigatorId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(InvestigationsQueries.AddInvestigatorQuery, new { investigationId, investigatorId });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public void CreateInvestigation(Investigation investigation)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(InvestigationsQueries.StartInvestigationQuery,
                    new
                    {
                        investigation.InvestigationId,
                        investigation.DealId,
                        investigation.Result,
                        investigation.Status,
                    });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }
    }
}
