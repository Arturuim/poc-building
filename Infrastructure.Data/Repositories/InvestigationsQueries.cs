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

        public static string GetById =>
            $@"SELECT TOP (1000) [a].[InvestigationId]
                    ,[DealId]
                    ,[Status]
                    ,[Result]
	                ,[b].[InvestigatorId]
	                ,[c].[Note]
               FROM [poc-Buildings].[dbo].[InvestigationsData] AS a
               INNER JOIN [dbo].[InvestigationParticipants] AS b On a.InvestigationId = b.InvestigationId
               INNER JOIN [dbo].[InvestigationNotes] AS c On a.InvestigationId = b.InvestigationId
               Where [a].[InvestigationId] = @InvestigationId";

        public static string CheckIfParticipantQuery =>
            $@"SELECT TOP (1) [InvestigatorId]
                    ,[InvestigationId]
               FROM [poc-Buildings].[dbo].[InvestigationParticipants]
               WHERE [InvestigationId] = @InvestigationId  AND 
                     [InvestigatorId] = @InvestigatorId;";
    }
}
