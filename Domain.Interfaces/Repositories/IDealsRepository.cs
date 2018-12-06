using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;

namespace Domain.Interfaces.Repositories
{
    public interface IDealsRepository
    {
        Deal GetDealById(string dealId);

        List<Deal> GetDealsByUserId(string userId);

        void CreateDeal(Deal deal);

        void ConfirmDeal(string dealId, string approvedId);

        void UpdateDeal(Deal deal);

        void DeleteDeals(string id);
    }
}
