using Dapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Infrastructure.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DealsRepository : RepositoryBase, IDealsRepository
    {
        public DealsRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void ConfirmDeal(string dealId, string confirmerId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(DealQueries.AcceptDealQuery, new { dealId, ownerId = confirmerId });
                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public void CreateDeal(Deal deal)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(DealQueries.CreateDealQuery,
                    new
                    {
                        deal.DealId,
                        deal.OwnerId,
                        deal.ApproverId,
                        deal.BuildingId,
                        deal.ClientId,
                        deal.CreationDate,
                        deal.EndDate,
                        deal.Price,
                        deal.Status
                    });

                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public void DeclineDeal(string dealId, string declinerId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                var res = conn.Execute(DealQueries.DeclineDealQuery, new { dealId, ownerId = declinerId });
                if (res == 0) { throw new InvalidOperationException("Error has occured!"); }
            }
        }

        public Deal GetDealById(string dealId)
        {
            using (var conn = new SqlConnection(this.ConnectionStringProvider.GetConnectionString()))
            {
                return conn.QueryFirstOrDefault<Deal>(DealQueries.GetDealByIdQuery, new { dealId });
            }
        }

        public List<Deal> GetDealsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
