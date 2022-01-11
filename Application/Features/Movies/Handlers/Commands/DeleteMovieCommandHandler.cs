using Application.DTO_s.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var validationResult = validator.Validate(request.DeleteMovieDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var movie = await _movieRepository.Get(request.DeleteMovieDTO.Id);

            await _movieRepository.Delete(movie);

            return Unit.Value;
        }
    }
}
