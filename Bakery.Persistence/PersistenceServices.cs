using Bakery.Application.Contracts.Identity;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Contracts.Sms;
using Bakery.Persistence.DbContexts;
using Bakery.Persistence.Repositories;
using Bakery.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bakery.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBakeryRepository, BakeryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISmsService, SmsService>();
            
            return services;
        }
    }
}
