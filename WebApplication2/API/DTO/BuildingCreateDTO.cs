using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.API.DTO
{
    public class BuildingCreateDTO
    {
        public string Address { get; set; }
        public Conditions Condition { get; set; }
        public decimal Price { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}