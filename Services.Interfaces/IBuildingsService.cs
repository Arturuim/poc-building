using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Services.Interfaces.DTO;

namespace Services.Interfaces
{
    public interface IBuildingsService
    {
        List<BuildingInfoDTO> GetByFilter(Filter filter);

        BuildingInfoDTO GetById(string buildingId);

        BuildingInfoDTO GetByAddress(string address);

        void AddNewBuilding(BuildingCreateDto newBuilding);
    }
}
