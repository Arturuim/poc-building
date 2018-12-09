using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Services.Interfaces;
using Services.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<BuildingInfoDTO> Get(Filter filter)
        {
            return this._buildingsRepo.GetBuildings(filter)
                .Select(x => Mapper.Map<BuildingInfoDTO>(x))
                .ToList();
        }

        public List<BuildingInfoDTO> GetBuildingsByAddress(string address)
        {
            return this._buildingsRepo.GetBuildingsByAddress(address)
                .Select(b => Mapper.Map<BuildingInfoDTO>(b))
                .ToList();
        }

        public BuildingInfoDTO GetBuildingById(string buildingID)
        {
            return Mapper.Map<BuildingInfoDTO>(this._buildingsRepo.GetBuildingById(buildingID));
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
