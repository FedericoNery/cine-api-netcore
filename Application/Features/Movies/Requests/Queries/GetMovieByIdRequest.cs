using Application.DTO_s;
using MediatR;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMovieByIdRequest : IRequest<MovieDTO>
    {
        public int Id { get; set; }
    }
}
