﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Investigation
    {
        public string InvestigationId { get; set; }
        public string RefuseId { get; set; }

        public List<string> Investigators { get; set; }
        public InvestigationStatuses Status { get; set; }

        public List<string> Notes { get; set; }

        public InvestigationResults Result { get; set; }
    }

    public enum InvestigationStatuses { NoStarted, InProgress, Finished }
    public enum InvestigationResults { Unclear, Postive, Negative }
}
