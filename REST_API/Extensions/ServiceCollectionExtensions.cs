using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace REST_API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DOTContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRepository<Users>, UserRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRepository<Roles>, RoleRepository>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IRepository<User_Sessions>, UserSessionRepository>()
                .AddScoped<IUserSessionService, UserSessionService>();
        }
    }
}
