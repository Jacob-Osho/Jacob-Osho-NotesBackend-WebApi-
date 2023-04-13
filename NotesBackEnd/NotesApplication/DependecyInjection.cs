using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using FluentValidation;
using NotesApplication.Common.Behaviors;

namespace NotesApplication
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            {
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

                return services;
            }
        }
    }
}
