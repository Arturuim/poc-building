using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Infrastructure
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
