namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Building
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }
        public Conditions Condition { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenedOn { get; set; }
        public DateTime ClosedBy { get; set; }

        public List<Comment> Comments { get; set; }

        public List<MetaData> MetaData { get; set; }
    }

    public enum Conditions
    {
        UnApproved,
        NotSatisfactual,
        Medium,
        Satisfactual,
        Excelent
    }

    public enum StayTime { }
}
