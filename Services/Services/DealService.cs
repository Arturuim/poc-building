using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using Services.Interfaces.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DealService : IDealService
    {
        private readonly IDealsRepository _dealsRepository;
        private readonly IBuildingsService _buildService;

        public DealService(IDealsRepository dealsRepository, IBuildingsService buildingsService)
        {
            this._dealsRepository = dealsRepository;
            this._buildService = buildingsService;
        }

        public void AcceptDeal(string dealId, string confirmerId)
        {
            var deal = this._dealsRepository.GetDealById(dealId);
            if (deal == null)
            {
                throw new InvalidOperationException($"Deal with id : {dealId} not found.");
            }

            if (deal.OwnerId != confirmerId|| deal.Status != DealStatus.InProgres) { throw new InvalidOperationException($"Wrong deal id: {dealId}."); }

            this._dealsRepository.ConfirmDeal(dealId, confirmerId);
        }


        public void CreateDeal(CreateDealDTO newDeal)
        {
            var deal = Mapper.Map<Deal>(newDeal);
            deal.Status = DealStatus.InProgres;

            // TODO : Cahnge to a real Approver service
            deal.ApproverId = newDeal.ClientId;


            var building = this._buildService.GetBuildingById(newDeal.BuildingId);
            deal.OwnerId = building.OwnerId;

            var dealTime = (deal.EndDate - deal.CreationDate).Days;
            deal.Price = building.Price * dealTime;

            this._dealsRepository.CreateDeal(deal);
        }

        public void DeclineDeal(string dealId, string declinerId)
        {
            var deal = this._dealsRepository.GetDealById(dealId);
            if (deal == null)
            {
                throw new InvalidOperationException($"Deal with id : {dealId} not found.");
            } 

            if(deal.OwnerId != declinerId || deal.Status != DealStatus.InProgres) { throw new InvalidOperationException($"Wrong deal id: {dealId}."); }

            this._dealsRepository.DeclineDeal(dealId, declinerId);
        }
    }
}
