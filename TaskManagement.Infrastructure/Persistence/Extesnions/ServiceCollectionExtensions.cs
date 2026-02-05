using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Infrastructure.Persistence.Extesnions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            return services;
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(connectionString,
            //       builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddDbContext<TaskManagmentDbContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                //.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                //.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<ITaskRepository, ITaskRepository>();
        }
    }
}