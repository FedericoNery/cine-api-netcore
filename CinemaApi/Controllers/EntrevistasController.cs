using Application.DTO_s.Entrevista;
using Application.Features.Entrevistas.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrevistasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EntrevistasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntrevistaFile>> Get(int id)
        {
            var entrevista = await _mediator.Send(new GetEntrevistaByIdRequest { Id = id });
            if (entrevista == null)
                return StatusCode(StatusCodes.Status204NoContent);
            return Ok(entrevista);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearEntrevistaDataContract crearEntrevistaDataContract)
        {
            var idEntrevista = await _mediator.Send(new CrearEntrevistaCommand
            {
                CrearEntrevistaDataContract = crearEntrevistaDataContract
            });
            return StatusCode(StatusCodes.Status201Created);
        }
/*
        [HttpPut("{id}")]
        public async Task<ActionResult<EntrevistaRespuestaDataContract>> Get(int id)
        {
            var entrevista = await _mediator.Send(new ResolverEntrevistaCommand { Id = id });
            if (entrevista == null)
                return StatusCode(StatusCodes.Status204NoContent);
            return Ok(entrevista);
        }*/
    }
}
