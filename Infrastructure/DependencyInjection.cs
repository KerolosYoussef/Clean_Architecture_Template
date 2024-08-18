using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Presistance;
using Domain.UserAggregate;
using Infrastructure.Authentication;
using Infrastructure.Extensions;
using Infrastructure.Presistence;
using Infrastructure.Presistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyApp.Infrastructure.Repositories;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, ConfigurationManager configurationManager) 
        {
            services
                .AddPresistance(configurationManager)
                .AddBuilders()
                .AddServices(configurationManager)
                .AddConfigurations(configurationManager)
                .AddIdentityServices(configurationManager);

            return services;
        }

        public static IServiceCollection AddPresistance(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            // Get data from appsettings
            var connectionString = configurationManager.GetConnectionString("DefaultConnection");
            var databaseProviderType = configurationManager.GetConnectionString("DatabaseProvider");
            // Add database
            services.AddDatabase(connectionString, databaseProviderType);

            // Add redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configurationManager.GetConnectionString("Redis");
                options.InstanceName = "Demo_";
            });

            // Add Presistance services 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));

            return services;
        }

        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            
            return services;
        }

        public static IServiceCollection AddConfigurations(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            
            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var _jwt = new JWT();
            configurationManager.Bind(JWT.SectionName, _jwt);
            services.AddSingleton(Options.Create(_jwt));
            services.AddTransient<IJWTTokenGenerator, JWTTokenGenerator>();

            var builder = services.AddIdentityCore<User>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddRoles<IdentityRole>();
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<User>>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _jwt.Issuer,
                        ValidAudience = _jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}
