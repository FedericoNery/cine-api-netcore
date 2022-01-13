using Application.DTO_s.Movie;
using MediatR;

namespace Application.Features.Movies.Requests
{
    public class CreateMovieCommand : IRequest<int>
    {
        public CreateMovieDTO CreateMovieDTO {get;set;}
    }
}
