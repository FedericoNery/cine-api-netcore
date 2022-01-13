using Application.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CinemaDbContext _dbContext;

        public MovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> FindByName(string name)
        {
            var movies = await _dbContext.Set<Movie>().ToListAsync();
            movies = movies.Where(x => x.Name.StartsWith(name)).ToList();
            return movies;
        }
    }
}
