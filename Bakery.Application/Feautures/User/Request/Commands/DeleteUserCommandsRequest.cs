using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.User.Request.Commands
{
    public class DeleteUserCommandsRequest : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
    }
}
