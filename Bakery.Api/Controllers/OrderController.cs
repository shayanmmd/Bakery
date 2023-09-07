using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Bakery.Application.Dtos.OrderDto;
using Bakery.Application.Feautures.Order.Request.Commands;
using Bakery.Application.Feautures.Order.Request.Quesries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Shared.Responses;

namespace Bakery.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [Route("/Order/Add")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> AddOrderAsync([FromBody] OrderDto orderDto)
        {
            try
            {
                var response = await _mediator.Send(new AddOrderCommandsRequest() { OrderDto = orderDto });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("/Order/Update")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> UpdateOrderAsync([FromBody] OrderDto orderDto)
        {
            try
            {
                var response = await _mediator.Send(new UpdateOrderCommandsRequest() { OrderDto = orderDto });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("/Order/Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> DeleteOrderAsync([FromHeader] Guid guid)
        {
            try
            {
                var response = await _mediator.Send(new DeleteOrderCommandsRequest() { Guid = guid });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("/Order/GetAll")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrderAsync([FromHeader] string token)
        {
            try
            {
                var response = await _mediator.Send(new GetAllOrderQueriesRequest());
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("/Order/GetOne")]
        public async Task<ActionResult<OrderDto>> GetOneOrderAsync([FromHeader] Guid guid)
        {
            try
            {

                var response = await _mediator.Send(new GetOrderrQueriesRequest() { Guid = guid });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

