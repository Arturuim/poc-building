using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Infrastructure.Data.Infrastructure;

namespace Infrastructure.Data.Repositories
{
    public static class BuildingQueries
    {
        public static string GetBuildingsByFilterQuery(Filter filter) =>
            $"SELECT * FROM [dbo].[Buildings] ORDER BY Id {filter.ToSql()}";

        public static string GetBuildingByIdQuery()
        {
            return $@"SELECT * FROM [dbo].[Buildings] WHERE Id=@buildingId";
        }

        public static string AddBuildingQuery()
        {
            return $@"INSERT INTO [dbo].[BuildingsData] (OwnerId, BuildingId, Address, Condition, Price, OpenTime, CloseTime, Is24Hours) 
                        VALUES (@OwnerId, @BuildingId, @Address, @Condition, @Price, @OpenTime, @CloseTime, @Is24Hours);";
        }

        public static string UpdateBuilding()
        {
            return $@"UPDATE [dbo].[BuildingsData] SET 
                        Address = @Address
                       ,Condition = @Condition 
                       ,Price = @Price 
                       ,OpenTime = @OpenTime 
                       ,CloseTime = @CloseTime 
                       ,Is24Hours = @Is24Hours
                      WHERE BuildingId = @BuildingId;";
        }
    }
}
