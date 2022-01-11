using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        //Acá irían las operaciones que son más específicas de Movie
    }
}
