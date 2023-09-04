using Bakery.Application.Dtos.BakeryDto;
using Bakery.Application.Feautures.Bakery.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Api.Controllers
{    
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
    }
}
