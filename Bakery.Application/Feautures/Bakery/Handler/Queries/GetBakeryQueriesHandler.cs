using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Dtos.BakeryDto;
using Bakery.Application.Feautures.Bakery.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.Bakery.Handler.Queries
{
    public class GetBakeryQueriesHandler : IRequestHandler<GetBakeryQueriesRequest, BakeryDto>
    {
        private readonly IBakeryRepository _bakeryRepository;
        private readonly IMapper _mapper;

        public GetBakeryQueriesHandler(IBakeryRepository bakeryRepository, IMapper mapper)
        {
            _bakeryRepository = bakeryRepository;
            _mapper = mapper;
        }
        public async Task<BakeryDto> Handle(GetBakeryQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _bakeryRepository.GetAsync(request.Guid);
            return _mapper.Map<BakeryDto>(toBeMappedEntity);
        }
    }
}
