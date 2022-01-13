using Application.DTO_s;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMovieByNameRequest : IRequest<List<MovieDTO>>
    {
        public string Name { get; set; }
    }
}
