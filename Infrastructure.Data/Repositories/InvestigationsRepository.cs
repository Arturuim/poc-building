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

        public void ChangeStatus(string investigationId, InvestigationStatuses status)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(InvestigationsQueries.ChangeStatusQuery(status), new { investigationId });

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

        public Investigation GetInvestigationById(string investigationId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var results = new List<Investigation>();

                return conn.Query<Investigation, string, string, Investigation>(InvestigationsQueries.GetById,
                    (invest, participant, note) =>
                    {
                        invest.Investigators = new List<string> { participant };
                        invest.Notes = new List<string> { note };

                        var test = results.FirstOrDefault(i => i.InvestigationId == invest.InvestigationId);

                        if (test == null)
                        {
                            results.Add(invest);
                        }
                        else
                        {
                            test.Notes.Add(note);
                            test.Investigators.Add(participant);
                        }

                        return invest;
                    },
                    new { investigationId },
                    splitOn: "InvestigatorId, Note").FirstOrDefault();
            }
        }

        public bool IsParticipantOfInvestigation(string investigationId, string overseerId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                return conn.QueryFirstOrDefault(InvestigationsQueries.CheckIfParticipantQuery, new { investigatorId = overseerId, investigationId }) != null;
            }
        }
    }
}
