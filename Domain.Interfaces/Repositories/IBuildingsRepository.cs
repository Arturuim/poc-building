using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IBuildingsRepository
    {
        List<Building> GetBuildings(Filter filter);
        List<Building> GetBuildingsByAddress(string address);
        Building GetBuildingByName(string name);
        Building GetBuildingById(string buildingId);
        void AddBuidling(Building building);
        void UpdateBuilding(Building building);
        void DeleteBuilding(string id);
    }
}
