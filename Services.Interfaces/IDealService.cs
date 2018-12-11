using Services.Interfaces.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDealService
    {
        void CreateDeal(CreateDealDTO newDeal);

        void AcceptDeal(string dealId, string confirmerId);

        void DeclineDeal(string dealId, string declinerId);
    }
}
