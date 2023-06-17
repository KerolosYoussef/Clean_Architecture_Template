using API.Common.Errors;
using API.Common.Mapping;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddTransient<ProblemDetailsFactory, ExtendedProblemDetailsFactory>();
            services.AddControllers();
            services.AddEndpointsApiExplorer()
               .AddSwaggerGen()
               .AddMapping()
               .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
               .AddNegotiate();
            services.AddAuthorization(options =>
               {
                   // By default, all incoming requests will be authorized according to the default policy.
                   options.FallbackPolicy = options.DefaultPolicy;
               });
            return services;
        }
    }
}
