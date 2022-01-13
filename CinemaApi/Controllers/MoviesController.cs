using Application.DTO_s;
using Application.DTO_s.Movie;
using Application.Features.Movies.Requests;
using Application.Features.Movies.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<MovieDTO>>> GetAllMovies(string sort, int pageNumber = 1, int pageSize = 10)
        {
            var movies = await _mediator.Send(new GetMoviesListRequest());
            
            /*
             *  TRASLADAR ESTA LÓGICA
            var movies = _dbContext.Movies.ToList();

            if (sort == "desc")
                movies = movies.OrderByDescending(x => x.TicketPrice).ToList();

            if (sort == "asc")
                movies = movies.OrderBy(x => x.TicketPrice).ToList();

            movies = movies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            */
            return Ok(movies);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<List<MovieDTO>>> FindByName(string name)
        {
            var movies = await _mediator.Send(new GetMovieByNameRequest{ Name = name });
            if (movies == null)
                return StatusCode(StatusCodes.Status204NoContent);
            return Ok(movies);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<MovieDTO>> MovieDetail(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdRequest {Id = id });
            if (movie == null)
                return StatusCode(StatusCodes.Status204NoContent);
            return Ok(movie);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddMovie([FromBody] CreateMovieDTO createMovieDTO)
        {
            var idMovie = await _mediator.Send(new CreateMovieCommand { 
                CreateMovieDTO = createMovieDTO
            });
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] UpdateMovieDTO updateMovieDTO)
        {
            updateMovieDTO.Id = id;

            var movie = await _mediator.Send(new UpdateMovieCommand {
                UpdateMovieDTO = updateMovieDTO
            });

            /*if (movieAActualizar == null)
            {
                return NotFound("No se encontró la película a actualizar");
            }*/
            return Ok("Se actualizó la película correctamente");
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _mediator.Send(new DeleteMovieCommand { Id = id });
            /*if (movie == null)
            {
                return NotFound("No se encontró la película a borrar");
            }*/
            return Ok("Se borró la película correctamente");
        }
    }
}
