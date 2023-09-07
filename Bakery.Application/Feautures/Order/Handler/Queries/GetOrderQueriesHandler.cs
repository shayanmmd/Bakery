using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Dtos.OrderDto;
using Bakery.Application.Feautures.Order.Request.Quesries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Order.Handler.Queries
{
    public class GetOrderQueriesHandler : IRequestHandler<GetOrderrQueriesRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueriesHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetOrderrQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _orderRepository.GetAsync(request.Guid);
            return _mapper.Map<OrderDto>(toBeMappedEntity);
        }
    }
}
