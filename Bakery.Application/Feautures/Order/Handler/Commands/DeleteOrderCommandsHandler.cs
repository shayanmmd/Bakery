using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Feautures.Order.Request.Commands;
using MediatR;
using Shared.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Order.Handler.Commands
{
    public class DeleteOrderCommandsHandler : IRequestHandler<DeleteOrderCommandsRequest, BaseResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<BaseResponse> Handle(DeleteOrderCommandsRequest request, CancellationToken cancellationToken)
        {
            return await _orderRepository.DeleteAsync(request.Guid);
        }
    }
}
