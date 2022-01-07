using CinemaApi.Data;
using CinemaApi.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class MoviesFake2Controller : ControllerBase
    {
        private CinemaDbContext _dbContext;

        public MoviesFake2Controller(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        //public IEnumerable<Movie> Get()
        public IActionResult Get()
        {
            return Ok(_dbContext.Movies);
            //return _dbContext.Movies;
            //return StatusCode(StatusCodes.Status200OK);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Movies.Find(id));
        }

        //api/movies/test/5
        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST api/<MoviesController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] Movie movie)
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

        // DELETE api/<MoviesController>/5
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
        }
    }
}
