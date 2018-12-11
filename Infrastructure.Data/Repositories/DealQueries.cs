using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DealQueries
    {
        public static string CreateDealQuery =>
            $@"INSERT INTO [dbo].[Deals] (DealId, OwnerId, ClientId, ApproverId, BuildingId, Price, Status, CreationDate, EndDate) 
              VALUES (@DealId, @OwnerId, @ClientId, @ApproverId, @BuildingId, @Price, @Status, @CreationDate, @EndDate);";

        public static string AcceptDealQuery =>
            $@"UPDATE [dbo].[Deals] SET Status = {(int)DealStatus.Confirmed} 
                WHERE DealId = @DealId AND OwnerId = @OwnerId;";

        public static string DeclineDealQuery =>
            $@"UPDATE [dbo].[Deals] SET Status = {(int)DealStatus.Declined} 
                WHERE DealId = @DealId AND OwnerId = @OwnerId;";

        public static string GetDealByIdQuery =>
            $@"SELECT DealId
                     ,OwnerId
                     ,ClientId
                     ,ApproverId
                     ,BuildingId
                     ,Price
                     ,Status
                     ,CreationDate
                     ,EndDate 
               FROM [dbo].[Deals]
               WHERE DealId = @DealId";
    }
}
