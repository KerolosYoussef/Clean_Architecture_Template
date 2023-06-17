using Application.Common.Interfaces.Presistance;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace API.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IMapper>(serviceProvider =>
            {
                var config = new TypeAdapterConfig();
                config.Apply(new UserMappingConfig(serviceProvider.GetRequiredService<IUserRepository>()));
                return new Mapper(config);
            });
            return services;
        }
    }
}
