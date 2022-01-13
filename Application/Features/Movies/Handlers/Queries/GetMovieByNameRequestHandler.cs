using Application.DTO_s;
using Application.Features.Movies.Requests.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMovieByNameRequestHandler : IRequestHandler<GetMovieByNameRequest, List<MovieDTO>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieByNameRequestHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<List<MovieDTO>> Handle(GetMovieByNameRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.FindByName(request.Name);
            return _mapper.Map<List<MovieDTO>>(movies);
        }
    }
}
