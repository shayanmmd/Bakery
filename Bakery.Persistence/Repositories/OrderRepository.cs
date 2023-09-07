using Bakery.Application.Contracts.Persistence;
using Bakery.Domain.Entities;
using Bakery.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly MainDbContext _mainDbContext;

        public OrderRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
    }
}
