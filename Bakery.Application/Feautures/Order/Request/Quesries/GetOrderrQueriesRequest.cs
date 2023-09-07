using Bakery.Application.Dtos.OrderDto;
using MediatR;
using System;

namespace Bakery.Application.Feautures.Order.Request.Quesries
{
    public class GetOrderrQueriesRequest : IRequest<OrderDto>
    {
        public Guid Guid { get; set; }
    }
}
