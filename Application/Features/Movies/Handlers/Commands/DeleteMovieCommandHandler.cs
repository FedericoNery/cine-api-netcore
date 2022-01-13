using Application.DTO_s.Movie;
using Application.DTO_s.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests;
using Application.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(
            IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteMovieDTOValidator();
            var deleteMovieDTO = new DeleteMovieDTO { Id = request.Id };
            var validationResult = validator.Validate(deleteMovieDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            await _movieRepository.DeleteById(request.Id);

            return Unit.Value;
        }
    }
}
