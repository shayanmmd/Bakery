using Bakery.Application.Contracts.Persistence;
using Bakery.Domain.Entities;
using Bakery.Persistence.DbContexts;
using Bakery.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IBakeryRepository, BakeryRepository>();
            return services;
        }
    }
}
