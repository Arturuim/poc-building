using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class InvestigationsQueries
    {
        public static string StartInvestigationQuery =>
            $@"INSERT INTO [dbo].[InvestigationsData](InvestigationId, DealId, Status, Result) VALUES 
               (@InvestigationId, @DealId, @Status, @Result);";

        public static string AddInvestigatorQuery =>
            $@"INSERT INTO [dbo].[InvestigationParticipants](InvestigationId, InvestigatorId) 
                VALUES (@InvestigationId, @InvestigatorId);";
    }
}
