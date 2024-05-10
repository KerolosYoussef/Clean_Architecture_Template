using Domain.Common.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Interfaces.Databases
{
    public interface IDatabase
    {
        public void ConnectToDatabase(IServiceCollection service, string connectionString);
    }
}
