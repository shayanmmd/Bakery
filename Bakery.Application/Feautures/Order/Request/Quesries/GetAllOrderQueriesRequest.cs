using Bakery.Application.Dtos.OrderDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Order.Request.Quesries
{
    public class GetAllOrderQueriesRequest : IRequest<IEnumerable<OrderDto>>
    {
    }
}
