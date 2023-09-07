using Bakery.Application.Dtos.OrderDto;
using MediatR;
using Shared.Responses;

namespace Bakery.Application.Feautures.Order.Request.Commands
{
    public class AddOrderCommandsRequest : IRequest<BaseResponse>
    {
        public OrderDto OrderDto { get; set; }
    }
}
