using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.DTO
{
    public class BuildingInfoDTO
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }
        public Conditions Condition { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenedOn { get; set; }
        public DateTime ClosedBy { get; set; }
    }
}
