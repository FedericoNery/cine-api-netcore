using Application.DataContract.Preguntas;
using Application.Features.Preguntas.Requests.Commands;
using Application.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Preguntas.Handlers.Commands
{
    public class CrearPreguntaCommandHandler : IRequestHandler<CrearPreguntaCommand, int>
    {
        private readonly IPreguntasRepository _preguntaRepository;
        private readonly IMapper _mapper;

        public CrearPreguntaCommandHandler(
            IPreguntasRepository preguntaRepository,
            IMapper mapper)
        {
            _preguntaRepository = preguntaRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearPreguntaCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateMovieDTOValidator();
            //var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);

            //if (validationResult.IsValid == false)
              //  throw new ValidationException(validationResult);

            var pregunta = _mapper.Map<CrearPreguntaDataContract, PreguntaRespuesta>(request.CrearPreguntaDataContract);

            pregunta = await _preguntaRepository.Create(pregunta);

            return pregunta.Id;
        }
    }
}
