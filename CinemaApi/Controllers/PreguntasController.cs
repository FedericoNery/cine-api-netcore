using Application.DataContract.Preguntas;
using Application.Features.Preguntas.Requests.Commands;
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
    public class PreguntasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PreguntasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearPreguntaDataContract crearPreguntaDataContract)
        {
            var idPregunta = await _mediator.Send(new CrearPreguntaCommand
            {
                CrearPreguntaDataContract = crearPreguntaDataContract
            });
            return StatusCode(StatusCodes.Status201Created);
        }

       /* [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
