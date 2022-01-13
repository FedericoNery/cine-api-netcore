using Application.DTO_s.Movie;
using Application.DTO_s.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests;
using Application.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public UpdateMovieCommandHandler(
            IMovieRepository movieRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieDTOValidator();
            var validationResult = validator.Validate(request.UpdateMovieDTO);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            
            //var movie = await _movieRepository.Get(request.UpdateMovieDTO.Id);

            /* DEBERIA IR LA VALIDACION DE QUE SI NO ENCUENTRA LA PELI
             * LA EXCEPCION SE LANZARIA ACA Y NO EN EL REPOSITORY
             * if (movie == null)
                 throw new NotFoundException();*/
            var updatedMovie = _mapper.Map<UpdateMovieDTO, Movie>(request.UpdateMovieDTO);
            await _movieRepository.Update(updatedMovie);

            return Unit.Value;
        }
    }
}
