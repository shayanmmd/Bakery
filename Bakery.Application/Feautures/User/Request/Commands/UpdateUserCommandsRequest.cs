using Bakery.Application.Dtos.UserDto;
using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.User.Request.Commands
{
    public class UpdateUserCommandsRequest : IRequest<BaseResponse>
    {
        public UserDto UserDto { get; set; }
    }
}
