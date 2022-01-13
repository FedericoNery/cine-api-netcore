using MediatR;

namespace Application.Features.Movies.Requests
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; }
    }
}
