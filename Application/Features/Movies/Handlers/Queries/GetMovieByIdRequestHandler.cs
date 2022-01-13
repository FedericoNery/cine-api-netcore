using Application.DTO_s;
using Application.Features.Movies.Requests.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMovieByIdRequestHandler : IRequestHandler<GetMovieByIdRequest, MovieDTO>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieByIdRequestHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<MovieDTO> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id);
            return _mapper.Map<MovieDTO>(movie);
        }
    }
}
