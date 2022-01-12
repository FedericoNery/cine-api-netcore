using Application.DTO_s;
using Application.DTO_s.Movie;
using Application.Features.Movies.Requests.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesListRequestHandler : IRequestHandler<GetMoviesListRequest, List<MovieDTO>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMoviesListRequestHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<List<MovieDTO>> Handle(GetMoviesListRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll();
            return _mapper.Map<List<MovieDTO>>(movies);
        }
    }
}
