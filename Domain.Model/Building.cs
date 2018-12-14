namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Building
    {
        public string OwnerId { get; set; }
        public string BuildingId { get; set; }
        public string Address { get; set; }
        public Conditions Condition { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool Is24Hours { get; set; }

        public List<Refuse> Refuses { get; set; }
        public List<MetaData> MetaData { get; set; }
    }

    public enum Conditions
    {
        Under_Approve,
        Satisfied,
        Fine
    }

    public enum StayTime { }
}
