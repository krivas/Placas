using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcentraVHM.Application.Exceptions;
using ConcentraVHM.Application.Features.Placas.Commands;
using ConcentraVHM.Application.Features.Placas.Commands.DeletePlaca;
using ConcentraVHM.Application.Features.Placas.Commands.UpdatePlaca;
using ConcentraVHM.Application.Features.Placas.Queries.GetPlacas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcentraVHM.Controllers
{
    [Route("api/[controller]")]
    public class PlacasController : Controller
    {
        private readonly IMediator _mediator;


        public PlacasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetPlacasQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server error");
            }

        }

        

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePlacaCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationErrors);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }

        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] UpdatePlacaCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationErrors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeletePlacaCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return NoContent();

            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationErrors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}

