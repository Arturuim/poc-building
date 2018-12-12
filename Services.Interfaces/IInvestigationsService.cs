using Services.Interfaces.DTO.Investigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInvestigationsService
    {
        InvestigationInfoDTO GetInvestigationInfoById(string investigationId);

        void StartInvestigation(string dealId, List<string> investigatorsIds);

        void AddNoteToInvestigation(string investigationId,string investigatorId, string note);

        bool CheckIfPartOfInvestigation(string investigationId, string investigatorId);
    }
}
