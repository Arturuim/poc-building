using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Infrastructure.Data.Infrastructure;
using Infrastructure.Data.Repositories;

using Domain.Interfaces.Repositories;
using Domain.Model;
using Domain.Interfaces;

namespace Data.MsSqlDataAcceess.Repositories
{
    public class BuildingsRepository : RepositoryBase, IBuildingsRepository
    {
        public BuildingsRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void AddBuidling(Building building)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(BuildingQueries.AddBuildingQuery(), new
                {
                    building.OwnerId,
                    building.BuildingId,
                    building.Address,
                    building.Condition,
                    building.Price,
                    building.OpenTime,
                    building.CloseTime,
                    building.Is24Hours
                });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public void DeleteBuilding(string id)
        {
            throw new NotImplementedException();
        }

        public List<Building> GetBuildingsByAddress(string address)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Query<Building>(BuildingQueries.GetBuildingByAddressQuery(), new { Address = $"%{address}%" })
                    .ToList();

                return res ?? throw new NullReferenceException($"Building with address : {address} not found.");
            }
        }

        public Building GetBuildingById(string buildingId)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.QueryFirstOrDefault<Building>(BuildingQueries.GetBuildingByIdQuery(), new { buildingId });
                return res ?? throw new NullReferenceException($"Building with id : {buildingId} not found.");
            }
        }

        public Building GetBuildingByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Building> GetBuildings(Filter filter)
        {
            using (var conn = new SqlConnection(ConnectionStringProvider.GetConnectionString()))
            {
                return conn.Query<Building>(BuildingQueries.GetBuildingsByFilterQuery(filter))
                    .ToList();
            }
        }

        public void UpdateBuilding(Building building)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(BuildingQueries.UpdateBuilding(), new
                {
                    building.BuildingId,
                    building.Address,
                    building.Condition,
                    building.Price,
                    building.OpenTime,
                    building.CloseTime,
                    building.Is24Hours
                });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }
    }
}
