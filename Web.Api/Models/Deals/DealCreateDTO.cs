using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Api.Models.Deals
{
    public class DealCreateDTO
    {
        public string BuildingId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}