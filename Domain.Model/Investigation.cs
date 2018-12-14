namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Investigation
    {
        public string InvestigationId { get; set; }
        public string DealId { get; set; }

        public List<string> Investigators { get; set; }
        public InvestigationStatuses Status { get; set; }

        public List<string> Notes { get; set; }

        public InvestigationResults Result { get; set; }
    }

    public enum InvestigationStatuses { NoStarted, InProgress, Finished }
    public enum InvestigationResults { Unclear, Postive, Negative }
}
