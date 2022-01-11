using Application.DTO_s;
using Application.DTO_s.Movie;
using Application.Features.Movies.Requests.Queries;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesListRequestHandler : IRequestHandler<GetMoviesListRequest, GetMoviesListDTO>
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
        public async Task<GetMoviesListDTO> Handle(GetMoviesListRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAll();
            return _mapper.Map<GetMoviesListDTO>(movies);
        }
    }
}
