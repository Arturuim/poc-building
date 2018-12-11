using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IDealsRepository
    {
        Deal GetDealById(string dealId);

        List<Deal> GetDealsByUserId(string userId);

        void CreateDeal(Deal deal);

        void ConfirmDeal(string dealId, string confirmerId);

        void DeclineDeal(string dealId, string declinerId);

        //void SuspectDeal(string dealId, string suspectorId);

        //void DeleteDeals(string id);
    }
}
