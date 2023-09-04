using Bakery.Application.Feautures.Bakery.Request.Commands;
using Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bakery.Application.Contracts.Persistence;
using AutoMapper;

namespace Bakery.Application.Feautures.Bakery.Handler.Commands
{
    public class AddBakeryCommandsHandler : IRequestHandler<AddBakeryCommandsRequest, BaseResponse>
    {
        private readonly IBakeryRepository _bakeryRepository;
        private readonly IMapper _mapper;

        public AddBakeryCommandsHandler(IBakeryRepository bakeryRepository, IMapper mapper)
        {
            _bakeryRepository = bakeryRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddBakeryCommandsRequest request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Domain.Entities.Bakery>(request.Bakery);
            return await _bakeryRepository.AddAsync(mappedEntity);
        }
    }
}
