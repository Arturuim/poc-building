using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IBuildingsRepository
    {
        List<Building> GetBuildings(Filter filter);
        Building GetBuildingByAddress(string address);
        Building GetBuildingByName(string name);
        Building GetBuildingById(string id);
        void AddBuidling(Building building);
        void UnpdateBuilding(string id, Building building);
        void DeleteBuilding(string id);
    }
}
