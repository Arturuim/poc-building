using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using Services.Interfaces.DTO.Investigations;
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
        private readonly IInvestigationNotesRepository _notesRepository;

        public InvestigationService(IInvestigationsRepository investigationsRepository, IInvestigationNotesRepository investigationNotesRepository)
        {
            _investigationsRepository = investigationsRepository;
            _notesRepository = investigationNotesRepository;
        }

        public void AddNoteToInvestigation(string investigationId, string investigatorId, string note)
        {
            this._notesRepository.CreateNote(investigationId, investigatorId, note);
        }

        public bool CheckIfPartOfInvestigation(string investigationId, string investigatorId)
        {
            return this._investigationsRepository.IsParticipantOfInvestigation(investigationId, investigatorId);
        }

        public InvestigationInfoDTO GetInvestigationInfoById(string investigationId)
        {
            return Mapper.Map<InvestigationInfoDTO>(this._investigationsRepository.GetInvestigationById(investigationId));
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

        public void ChangeStatus(string investigationId, string status)
        {
            Enum.TryParse(status, out InvestigationStatuses parseStatus);
            this._investigationsRepository.ChangeStatus(investigationId, parseStatus);
        }
    }
}


//private bool IsParticipant(string investigationId, string investigatorId)
//{
//    var investigation = this._investigationsRepository.GetById(investigation)
//}
