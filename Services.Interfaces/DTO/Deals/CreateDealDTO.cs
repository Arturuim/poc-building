using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.DTO.Deals
{
    public class CreateDealDTO
    {
        public string OwnerId { get; set; }
        public string ClientId { get; set; }
        public string BuildingId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
