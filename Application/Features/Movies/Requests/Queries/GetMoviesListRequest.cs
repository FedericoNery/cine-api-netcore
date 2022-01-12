using Application.DTO_s;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMoviesListRequest : IRequest<List<MovieDTO>>
    {
    }
}
