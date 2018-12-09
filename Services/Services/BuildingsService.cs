using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using Services.Interfaces.DTO;
using System;

namespace Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly IBuildingsRepository _buildingsRepo;

        public BuildingsService(IBuildingsRepository buildingsRepo)
        {
            _buildingsRepo = buildingsRepo;
        }

        public void AddNewBuilding(BuildingCreateDto newBuilding)
        {
            this._buildingsRepo.AddBuidling(Mapper.Map<Building>(newBuilding));
        }

        public void UpdateBuildingInfo(BuildingCreateDto buidlingInfo, string buildingId)
        {
            var building = Mapper.Map<Building>(buidlingInfo);
            building.BuildingId = buildingId;
            building.Condition = Conditions.Under_Approve;
            this._buildingsRepo.UpdateBuilding(building);
        }
    }
}
