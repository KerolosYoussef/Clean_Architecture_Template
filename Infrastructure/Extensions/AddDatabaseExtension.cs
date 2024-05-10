using Application.Common.Interfaces.Databases;
using Domain.Common.Enums;
using Infrastructure.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class AddDatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            // get database connection string and provider
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var databaseProviderType = Enum.Parse<DatabaseProvider>(Environment.GetEnvironmentVariable("databaseProviderType"));
            IDatabase databaseProvider;
            // instantiate the correct database provider
            switch (databaseProviderType)
            {
                case DatabaseProvider.Mysql:
                    {
                        databaseProvider = new MySqlDatabaseProvider();
                        break;
                    }
                case DatabaseProvider.Mssql:
                    {
                        databaseProvider = new MssqlDatabaseProvider();
                        break;
                    }
                default:
                    throw new ArgumentException("Invalid database provider type");
            }

            // connect to database
            databaseProvider.ConnectToDatabase(services, connectionString);

            return services;
        }
    }
}
