using Bakery.Application.Dtos.BakeryDto;
using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Bakery.Request.Commands
{
    public class UpdateBakeryCommandsRequest : IRequest<BaseResponse>
    {
        public BakeryDto Bakery { get; set; }
    }
}
