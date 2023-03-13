using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using ConcentraVHM.Application.Exceptions;
using ConcentraVHM.Application.Features.Clientes;
using ConcentraVHM.Application.Features.Clientes.Commands.CreateCliente;
using ConcentraVHM.Application.Features.Clientes.Commands.DeleteCliente;
using ConcentraVHM.Application.Features.Clientes.Commands.UpdateClient;
using ConcentraVHM.Application.Features.Clientes.Queries.GetClientes;
using MediatR;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcentraVHM.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ClientesController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new GetClientesQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server error");
            }
            
        }

       
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateClienteCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode(201);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.ValidationErrors);
            }
            catch (ExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

      
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateClienteCommand request)
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
            catch (NotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        // DELETE api/values/5
        [HttpDelete("{cedula}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteClienteCommand request)
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

