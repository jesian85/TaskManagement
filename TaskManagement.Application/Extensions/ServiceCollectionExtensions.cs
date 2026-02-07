using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagement.Application.Services;

namespace TaskManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ITaskService, TaskService>();
            return services;
        }
    }
}