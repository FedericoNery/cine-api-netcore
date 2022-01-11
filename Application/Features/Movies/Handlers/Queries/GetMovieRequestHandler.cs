using Application.DTO_s.Movie;
using Application.Features.Movies.Requests.Queries;
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
    public class GetMovieRequestHandler : IRequestHandler<GetMovieRequest, GetMovieDTO>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieRequestHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public Task<GetMovieDTO> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            /*var movie = _movieRepository.Get(request.Id);
            return _mapper.Map<GetMovieDTO>(movie);*/
        }
    }
}
