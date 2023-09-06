using Bakery.Application.Dtos.UserDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.User.Request.Queries
{
    public class GetAllUserQueriesRequest : IRequest<IEnumerable<UserDto>>
    {
    }
}
