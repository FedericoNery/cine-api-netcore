using Application.DTO_s.Movie;
using MediatR;

namespace Application.Features.Movies.Requests
{
    public class UpdateMovieCommand : IRequest
    {
        public UpdateMovieDTO UpdateMovieDTO { get; set; }
    }
}
