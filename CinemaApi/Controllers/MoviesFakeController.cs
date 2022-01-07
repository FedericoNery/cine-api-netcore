using CinemaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesFakeController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>()
        {
            new Movie(){ Id=0, Name="Toy Story", Language="English"},
            new Movie(){ Id=1, Name="Matrix", Language="English"},
            new Movie(){ Id=2, Name="Coco", Language="English"},
        };

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        [HttpPost]
        public void CreateMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(int id, [FromBody] Movie movie)
        {
            var movieAActualizar = movies.Where(x => x.Id == id).FirstOrDefault();
            var indice = movies.IndexOf(movieAActualizar);
            movies[indice].Language = movie.Language;
            movies[indice].Name = movie.Name;
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            var movieABorrar = movies.Where(x => x.Id == id).FirstOrDefault();
            var indice = movies.IndexOf(movieABorrar);
            movies.Remove(movieABorrar);
        }
    }
}
