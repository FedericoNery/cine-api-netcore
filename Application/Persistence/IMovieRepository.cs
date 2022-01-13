using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        //Acá irían las operaciones que son más específicas de Movie
        Task<List<Movie>> FindByName(string name);

    }
}
