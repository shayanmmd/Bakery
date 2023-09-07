using Bakery.Application.Dtos.OrderDto;
using MediatR;
using Shared.Responses;

namespace Bakery.Application.Feautures.Order.Request.Commands
{
    public class UpdateOrderCommandsRequest : IRequest<BaseResponse>
    {
        public OrderDto OrderDto { get; set; }
    }
}
