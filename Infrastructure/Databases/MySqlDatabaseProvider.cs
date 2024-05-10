using Application.Common.Interfaces.Databases;
using Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Databases
{
    internal class MySqlDatabaseProvider : IDatabase
    {
        public void ConnectToDatabase(IServiceCollection service, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);
        }
    }
}
