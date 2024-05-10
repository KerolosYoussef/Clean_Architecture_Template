using API.Common.Errors;
using API.Common.Mapping;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddTransient<ProblemDetailsFactory, ExtendedProblemDetailsFactory>();
            services.AddControllers();
            services.AddEndpointsApiExplorer()
               .AddSwaggerGen(s =>
               {
                   s.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                   {
                       In = ParameterLocation.Header,
                       Description = "Bearer Authentication using bearer scheme",
                       Name = "Authorization",
                       Type = SecuritySchemeType.Http,
                       BearerFormat = "JWT",
                       Scheme = "bearer"
                   });
                   s.AddSecurityRequirement(new OpenApiSecurityRequirement
                   {
                       {
                           new OpenApiSecurityScheme
                           {
                               Reference = new OpenApiReference
                               {
                                   Type = ReferenceType.SecurityScheme,
                                   Id = "bearer"
                               }
                           },
                           new string[]{}
                       }
                   });
               })
               .AddMapping()
               .AddRouting(options => options.LowercaseUrls = true)
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
