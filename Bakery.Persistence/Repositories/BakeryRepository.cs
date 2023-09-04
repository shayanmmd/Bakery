using Bakery.Application.Contracts.Persistence;
using Bakery.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Persistence.Repositories
{
    public class BakeryRepository : GenericRepository<Domain.Entities.Bakery> , IBakeryRepository
    {
        private readonly MainDbContext _mainDbContext;

        public BakeryRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
    }
}
