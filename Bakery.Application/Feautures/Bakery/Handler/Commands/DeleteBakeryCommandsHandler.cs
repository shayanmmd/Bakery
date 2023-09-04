using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Feautures.Bakery.Request.Commands;
using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Bakery.Handler.Commands
{
    public class DeleteBakeryCommandsHandler : IRequestHandler<DeleteBakeryCommandsRequest, BaseResponse>
    {
        private readonly IBakeryRepository _bakeryRepository;
        public DeleteBakeryCommandsHandler(IBakeryRepository bakeryRepository)
        {
            _bakeryRepository = bakeryRepository;
        }
        public Task<BaseResponse> Handle(DeleteBakeryCommandsRequest request, CancellationToken cancellationToken)
        {
            return _bakeryRepository.DeleteAsync(request.Guid);
        }
    }
}
