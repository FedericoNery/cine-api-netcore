using Application.DTO_s.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var movie = _mapper.Map<Movie>(request.CreateMovieDTO);

            movie = await _movieRepository.Create(movie);

            return movie.Id;
        }
    }
}
