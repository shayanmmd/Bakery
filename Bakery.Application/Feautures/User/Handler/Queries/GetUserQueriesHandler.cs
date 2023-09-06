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
    public class GetUserQueriesHandler : IRequestHandler<GetUserQueriesRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueriesHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserQueriesRequest request, CancellationToken cancellationToken)
        {
            var toBeMappedEntity = await _userRepository.GetAsync(request.Guid);
            return _mapper.Map<UserDto>(toBeMappedEntity);
        }
    }
}
