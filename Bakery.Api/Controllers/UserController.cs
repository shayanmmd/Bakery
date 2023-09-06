using Bakery.Application.Contracts.Persistence;
using Bakery.Application.Dtos.UserDto;
using Bakery.Application.Feautures.User.Request.Commands;
using Bakery.Application.Feautures.User.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("/User/GetAll")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUserAsync()
        {
            try
            {
                var response = await _mediator.Send(new GetAllUserQueriesRequest());
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("/User/GetOne")]
        public async Task<ActionResult<UserDto>> GetOneUserAsync()
        {
            try
            {
                var response = await _mediator.Send(new GetUserQueriesRequest());
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("/User/Add")]
        public async Task<ActionResult<IEnumerable<UserDto>>> AddUserAsync([FromBody] UserDto userDto)
        {
            try
            {
                var response = await _mediator.Send(new AddUserCommandsRequest() { UserDto = userDto});
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        [Route("/User/Update")]
        public async Task<ActionResult<BaseResponse>> UpdateUserAsync([FromBody] UserDto userDto)
        {
            try
            {
                var response = await _mediator.Send(new UpdateUserCommandsRequest() { UserDto = userDto });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("/User/Delete")]
        public async Task<ActionResult<BaseResponse>> DeleteUserAsync([FromHeader] Guid guid)
        {
            try
            {
                var response = await _mediator.Send(new DeleteUserCommandsRequest() {Guid = guid });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
