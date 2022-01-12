using Domain;

namespace Application.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        //Acá irían las operaciones que son más específicas de Movie
    }
}
