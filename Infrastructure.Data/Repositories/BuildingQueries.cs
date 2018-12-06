using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Data.Infrastructure;

namespace Infrastructure.Data.Repositories
{
    public static class BuildingQueries
    {
        public static  string GetBuildingsByFilterQuery(Filter filter) =>
            $"SELECT * FROM [dbo].[BuildingsInfo] ORDER BY Id {filter.ToSql()}";

        public static string GetBuildingByIdQuery()
        {
            return $@"SELECT * FROM [dbo].[BuildingsInfo] WHERE Id=@buildingId";
        }

        public static string GetBuildingByAddress()
        {
            return $@"SELECT * FROM [dbo].[BuildingsInfo] WHERE Address=@address";
        }

        public static string InsertBuildingQuery()
        {
            return $@"INSERT INTO [dbo].[BuildingsInfo] (Id, OwnerId, Address, Condition, Price, OpendOn, ClosedOn)
                      VALUES (@Id, @OwnerId, @Address, @Condition, @Price, @OpendOn, @ClosedOn);";
        }
    }
}
