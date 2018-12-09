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
        private readonly IConnectionStringProvider _connStrProvider;

        public BuildingsRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
            this._connStrProvider = connectionStringProvider;
        }

        public void AddBuidling(Building building)
        {
            using (var conn = new SqlConnection(this._connStrProvider.GetConnectionString()))
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

                if(res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public void DeleteBuilding(string id)
        {
            throw new NotImplementedException();
        }

        public Building GetBuildingByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public Building GetBuildingById(string id)
        {
            throw new NotImplementedException();
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
            using (var conn = new SqlConnection(this._connStrProvider.GetConnectionString()))
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
