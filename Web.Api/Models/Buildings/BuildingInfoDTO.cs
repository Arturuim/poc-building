using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Web.Api.Models.Buildings
{
    public class BuildingInfoDTO
    {
        public string BuildingId { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }
        public Conditions Condition { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public bool Is24Hours { get; set; }
    }
}