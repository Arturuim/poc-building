using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Infrastructure
{
    public class MsSqlConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public MsSqlConnectionStringProvider(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public string GetConnectionString() =>  this._connectionString;
    }
}
