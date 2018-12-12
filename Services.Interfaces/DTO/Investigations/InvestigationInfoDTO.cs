using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.DTO.Investigations
{
    public class InvestigationInfoDTO
    {
        public string InvestigationId { get; set; }
        public string DealId { get; set; }

        public List<string> Investigators { get; set; }
        public InvestigationStatuses Status { get; set; }

        public List<string> Notes { get; set; }

        public InvestigationResults Result { get; set; }
    }
}
