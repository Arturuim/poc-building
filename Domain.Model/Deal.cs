namespace Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Deal
    {
        public string DealId { get; set; }
        public string OwnerId { get; set; }
        public string ClientId { get; set; }
        public string BuildingId { get; set; }

        public decimal Price { get; set; }
        public DealStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ApproverId { get; set; }
    }

    public  enum DealStatus { InProgres, Confirmed, Declined, Approved, Blocked }
}
