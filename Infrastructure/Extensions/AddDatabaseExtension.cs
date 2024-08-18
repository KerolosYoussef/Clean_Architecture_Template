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
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString, string databaseType)
        {
            // get database connection string and provider
            var databaseProviderType = Enum.Parse<DatabaseProvider>(databaseType);

            // instantiate the correct database provider
            IDatabase databaseProvider = databaseProviderType switch
            {
                DatabaseProvider.Mysql => new MySqlDatabaseProvider(),
                DatabaseProvider.Mssql => new MssqlDatabaseProvider(),
                _ => throw new ArgumentException("Invalid database provider type")
            };

            // connect to database
            databaseProvider.ConnectToDatabase(services, connectionString);

            return services;
        }
    }
}
