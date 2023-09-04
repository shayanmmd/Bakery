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
    public class UpdateBakeryCommandsHandler : IRequestHandler<UpdateBakeryCommandsRequest, BaseResponse>
    {
        private readonly IBakeryRepository _bakeryRepository;
        private readonly IMapper _mapper;

        public UpdateBakeryCommandsHandler(IBakeryRepository bakeryRepository, IMapper mapper)
        {
            _bakeryRepository = bakeryRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateBakeryCommandsRequest request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Domain.Entities.Bakery>(request.Bakery);
            return await _bakeryRepository.UpdateAsync(mappedEntity);
        }
    }
}
