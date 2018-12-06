﻿using System;
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
            throw new NotImplementedException();
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

        public void UnpdateBuilding(string id, Building building)
        {
            throw new NotImplementedException();
        }
    }
}
