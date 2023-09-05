using Bakery.Application.Dtos.BakeryDto;
using Bakery.Application.Feautures.Bakery.Request.Commands;
using Bakery.Application.Feautures.Bakery.Request.Queries;
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
    [Authorize]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BakeryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("/Bakery/GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryDto>>> GetAllBakery()
        {
            try
            {
                var response = await _mediator.Send(new GetAllBakeryQueriesRequest());
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("/Bakery/GetOne")]
        [HttpGet]
        public async Task<ActionResult<BakeryDto>> GetOneBakery([FromHeader] Guid guid)
        {
            try
            {
                var response = await _mediator.Send(new GetBakeryQueriesRequest() { Guid = guid });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("/Bakery/Add")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> AddBakeryAsync([FromBody] BakeryDto bakeryDto)
        {
            try
            {
                var response = await _mediator.Send(new AddBakeryCommandsRequest() { Bakery = bakeryDto });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("/Bakery/Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateBakeryAsync([FromBody] BakeryDto bakeryDto)
        {
            try
            {
                var response = await _mediator.Send(new UpdateBakeryCommandsRequest() { Bakery = bakeryDto });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [Route("/Bakery/Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteBakeryAsync([FromHeader] Guid guid)
        {
            try
            {
                var response = await _mediator.Send(new DeleteBakeryCommandsRequest() { Guid = guid });
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
