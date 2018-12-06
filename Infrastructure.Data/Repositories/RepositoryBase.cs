using Infrastructure.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public  class RepositoryBase
    {
        protected IConnectionStringProvider ConnectionStringProvider;
        public RepositoryBase(IConnectionStringProvider connectionStringProvider)
        {
            this.ConnectionStringProvider = connectionStringProvider;
        }
    }
}
