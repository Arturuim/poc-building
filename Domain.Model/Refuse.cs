namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Refuse
    {
        public string RefuseId { get; set; }
        public string BuildingId { get; set; }
        public string AuthorId { get; set; }

        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public RefuseStatus Status { get; set; }
        public string ApproverId  { get; set; }
    }


    public enum RefuseStatus { Unspecified, Approved, Rejected }
}
