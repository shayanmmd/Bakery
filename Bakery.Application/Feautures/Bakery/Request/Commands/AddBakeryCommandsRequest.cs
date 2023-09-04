using Bakery.Application.Dtos.BakeryDto;
using Shared.Responses;
using MediatR;

namespace Bakery.Application.Feautures.Bakery.Request.Commands
{
    public class AddBakeryCommandsRequest : IRequest<BaseResponse>
    {
        public BakeryDto Bakery { get; set; }
    }
}
