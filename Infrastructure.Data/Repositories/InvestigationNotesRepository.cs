using Dapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class InvestigationNotesRepository : RepositoryBase, IInvestigationNotesRepository
    {
        public InvestigationNotesRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void CreateNote(string investigationId, string investigatorId, string note)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(InvestigationNotesQueries.AddNoteString, new { investigationId, investigatorId, note });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }
    }
}
