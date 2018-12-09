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
    }
}
