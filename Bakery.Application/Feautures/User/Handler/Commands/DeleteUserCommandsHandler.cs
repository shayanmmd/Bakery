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
    public class DeleteUserCommandsHandler : IRequestHandler<DeleteUserCommandsRequest, BaseResponse>
    {
        private readonly IUserRepository _userRepository;        
        public DeleteUserCommandsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse> Handle(DeleteUserCommandsRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteAsync(request.Guid);
        }
    }
}
