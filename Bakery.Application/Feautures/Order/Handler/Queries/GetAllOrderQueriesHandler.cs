using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Dtos.OrderDto;
using Bakery.Application.Feautures.Order.Request.Quesries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Order.Handler.Queries
{
    public class GetAllOrderQueriesHandler : IRequestHandler<GetAllOrderQueriesRequest, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueriesHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrderQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(toBeMappedEntity);
        }
    }
}
