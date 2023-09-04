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
    public class GetAllBakeryQuriesHandler : IRequestHandler<GetAllBakeryQueriesRequest, IEnumerable<BakeryDto>>
    {
        private readonly IBakeryRepository _bakeryRepository;
        private readonly IMapper _mapper;

        public GetAllBakeryQuriesHandler(IBakeryRepository bakeryRepository, IMapper mapper)
        {
            _bakeryRepository = bakeryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BakeryDto>> Handle(GetAllBakeryQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _bakeryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BakeryDto>>(toBeMappedEntity);
        }
    }
}
