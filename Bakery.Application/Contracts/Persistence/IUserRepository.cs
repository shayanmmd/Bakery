﻿using Bakery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByPhoneNumber(string phoneNumber);
    }
}
