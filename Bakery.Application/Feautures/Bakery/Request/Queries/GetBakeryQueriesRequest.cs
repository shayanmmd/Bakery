using Bakery.Application.Dtos.BakeryDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Bakery.Request.Queries
{
    public class GetBakeryQueriesRequest : IRequest<BakeryDto>
    {
        public Guid Guid { get; set; }
    }
}
