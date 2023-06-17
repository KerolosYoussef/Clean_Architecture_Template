using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Authentication.Common;
using Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;
using ErrorOr;
using Application.Common.Interfaces.Sepcification;
using Application.Specifications;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(ISpecification<>), typeof(BaseSpecification<>));

            return services;
        }
    }
}
