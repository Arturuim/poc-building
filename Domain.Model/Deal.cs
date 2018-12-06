namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Deal
    {
        protected string Id;
        public string OwnerId { get; set; }
        public string UserId { get; set; }
        public string BuildingId { get; set; }
        public DealStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string ApproverBy { get; set; }
        public decimal Price { get; set; }
    }

    public  enum DealStatus { }
}
