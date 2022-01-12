using Application.Persistence;
using Domain;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CinemaDbContext _dbContext;

        public MovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
