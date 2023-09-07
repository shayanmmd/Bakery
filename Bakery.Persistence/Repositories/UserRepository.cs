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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly MainDbContext _mainDbContext;

        public UserRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public User FindByPhoneNumber(string phoneNumber)
        {
            return _mainDbContext.Set<User>().SingleOrDefault(x => x.PhoneNumber == phoneNumber);
        }
    }
}
