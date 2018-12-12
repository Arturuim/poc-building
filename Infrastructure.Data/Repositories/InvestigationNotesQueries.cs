using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class InvestigationNotesQueries
    {
        public static string AddNoteString =>
            $@"INSERT INTO [dbo].[InvestigationNotes](InvestigationId, InvestigatorId, Note) 
                VALUES (@InvestigationId, @InvestigatorId, @Note);";
    }
}
