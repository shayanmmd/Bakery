using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Dtos.UserDto;
using Bakery.Application.Feautures.User.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.User.Handler.Queries
{
    public class GetAllUserQueriesHandler : IRequestHandler<GetAllUserQueriesRequest, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueriesHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUserQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(toBeMappedEntity);
            
        }
    }
}
