using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Services.Interfaces;
using Services.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly IBuildingsRepository _reppo;

        public BuildingsService(IBuildingsRepository reppo)
        {
            _reppo = reppo;
        }

        public void AddNewBuilding(BuildingCreateDto newBuilding)
        {
            newBuilding.OwnerId = Guid.NewGuid().ToString();
            this._reppo.AddBuidling(Mapper.Map<Building>(newBuilding));
        }

        public BuildingInfoDTO GetByAddress(string address)
        {
            return Mapper.Map<BuildingInfoDTO>(this._reppo.GetBuildingByAddress(address));
        }

        public List<BuildingInfoDTO> GetByFilter(Filter filter)
        {
            return _reppo.GetBuildings(filter)
                .Select(b => Mapper.Map<BuildingInfoDTO>(b))
                .ToList();
        }

        public BuildingInfoDTO GetById(string buildingId)
        {
            return Mapper.Map<BuildingInfoDTO>(_reppo.GetBuildingById(buildingId));
        }
    }
}
