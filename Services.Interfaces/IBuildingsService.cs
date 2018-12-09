using Domain.Interfaces;
using Services.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBuildingsService
    {
        List<BuildingInfoDTO> Get(Filter filter);

        BuildingInfoDTO GetBuildingById(string buildingID);

        List<BuildingInfoDTO> GetBuildingsByAddress(string address);

        void AddNewBuilding(BuildingCreateDto newBuilding);

        void UpdateBuildingInfo(BuildingCreateDto buidlingInfo, string buildingId);
    }
}
