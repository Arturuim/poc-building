using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IInvestigationsRepository
    {
        void CreateInvestigation(Investigation investigation);

        void AddInvestigator(string investigationId, string investigatorId);

        Investigation GetInvestigationById(string investigationId);

        bool IsParticipantOfInvestigation(string investigationId, string overseerId);

        void ChangeStatus(string investigationId, InvestigationStatuses status);
    }
}
