using Application.Common.Interfaces.Databases;
using Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Databases
{
    internal class MssqlDatabaseProvider : IDatabase
    {
        public void ConnectToDatabase(IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ApplicationDbContext>(option
                => option.UseSqlServer(connectionString));
        }
    }
}
