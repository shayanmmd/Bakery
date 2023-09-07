using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Feautures.Order.Request.Commands;
using MediatR;
using Shared.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Order.Handler.Commands
{
    public class UpdateOrderCommandsHandler : IRequestHandler<UpdateOrderCommandsRequest, BaseResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandsHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateOrderCommandsRequest request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Domain.Entities.Order>(request.OrderDto);
            return await _orderRepository.UpdateAsync(mappedEntity);
        }
    }
}
