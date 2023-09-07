using MediatR;
using Shared.Responses;
using System;

namespace Bakery.Application.Feautures.Order.Request.Commands
{
    public class DeleteOrderCommandsRequest : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
    }
}
