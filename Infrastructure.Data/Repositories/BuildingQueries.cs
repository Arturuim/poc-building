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
            $"SELECT * FROM [dbo].[Buildings] ORDER BY Id {filter.ToSql()}";

        public static string GetBuildingByIdQuery()
        {
            return $@"SELECT * FROM [dbo].[Buildings] WHERE Id=@buildingId";
        }
    }
}
