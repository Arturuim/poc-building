using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class InvestigationService : IInvestigationsService
    {
        private readonly IInvestigationsRepository _investigationsRepository;

        public InvestigationService(IInvestigationsRepository investigationsRepository)
        {
            _investigationsRepository = investigationsRepository;
        }

        public void StartInvestigation(string dealId, List<string> investigatorsIds)
        {
            var investigation = new Investigation()
            {
                DealId = dealId,
                InvestigationId = Guid.NewGuid().ToString(),
                Result = InvestigationResults.Unclear,
                Status = InvestigationStatuses.InProgress
            };

            this._investigationsRepository.CreateInvestigation(investigation);

            investigatorsIds.ForEach(id => this._investigationsRepository.AddInvestigator(investigation.InvestigationId, id));
        }
    }
}
