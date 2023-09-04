using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Bakery.Request.Commands
{
    public class DeleteBakeryCommandsRequest : IRequest<BaseResponse>
    {
        public Guid Guid { get; set; }
    }
}
