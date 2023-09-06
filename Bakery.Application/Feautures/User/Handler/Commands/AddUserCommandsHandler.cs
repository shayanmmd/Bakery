using AutoMapper;
using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Feautures.User.Request.Commands;
using MediatR;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bakery.Application.Feautures.User.Handler.Commands
{
    public class AddUserCommandsHandler : IRequestHandler<AddUserCommandsRequest, BaseResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandsHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(AddUserCommandsRequest request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<Domain.Entities.User>(request.UserDto);
            return await _userRepository.AddAsync(mappedEntity);
        }
    }
}
