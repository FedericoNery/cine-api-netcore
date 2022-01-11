using Application.Features.Movies.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
       // [Authorize]
        public IActionResult GetAllMovies(string sort, int pageNumber = 1, int pageSize = 10)
        {
            var movies = _mediator.Send(new GetMoviesListRequest());
            
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

      /*  [HttpGet("[action]")]
        [Authorize]
        public IActionResult FindByName(string name)
        {
            var movies = _dbContext.Movies.Where(x => x.Name.StartsWith(name)).ToList();
            if (movies.Count == 0)
                return StatusCode(StatusCodes.Status204NoContent);
            else
                return Ok(movies);
        }*/

     /*   [HttpGet("{id}")]
        [Authorize]
        public IActionResult MovieDetail(int id)
        {
            return Ok(_dbContext.Movies.Find(id));
        }*/

     /*   [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie([FromForm] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }*/

       /* [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateMovie(int id, [FromForm] Movie movie)
        {
            var movieAActualizar = _dbContext.Movies.Find(id);
            if (movieAActualizar == null)
            {
                return NotFound("No se encontró la película a actualizar");
            }
            movieAActualizar.Language = movie.Language;
            movieAActualizar.Name = movie.Name;
            movieAActualizar.Rating = movie.Rating;
            _dbContext.Movies.Update(movieAActualizar);
            _dbContext.SaveChanges();
            return Ok("Se actualizó la película correctamente");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound("No se encontró la película a borrar");
            }
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return Ok("Se borró la película correctamente");
        }*/
    }
}
