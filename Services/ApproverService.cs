using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Services.Interfaces;

namespace Services
{
    class ApproverService : IApproverService
    {
        private readonly IApproverRepository _approverRepo;

        public ApproverService(IApproverRepository approverRepo)
        {
            _approverRepo = approverRepo;
        }

        public void ApproveComment(string commentId, string approverId)
        {
            this._approverRepo.ApproveComment(commentId, approverId);
        }
    }
}
