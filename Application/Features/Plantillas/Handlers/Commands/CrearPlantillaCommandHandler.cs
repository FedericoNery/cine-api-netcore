using Application.DTO_s.Plantilla;
using Application.Features.Plantillas.Requests.Commands;
using Application.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Plantillas.Handlers.Commands
{
    public class CrearPlantillaCommandHandler : IRequestHandler<CrearPlantillaCommand, int>
    {
        private readonly IPlantillaRepository _plantillaRepository;
        private readonly IMapper _mapper;

        public CrearPlantillaCommandHandler(
            IPlantillaRepository preguntaRepository,
            IMapper mapper)
        {
            _plantillaRepository = preguntaRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearPlantillaCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateMovieDTOValidator();
            //var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);

            //if (validationResult.IsValid == false)
            //  throw new ValidationException(validationResult);
            Guid guid = Guid.NewGuid();
            var weatherForecast = new
            {
                Preguntas = request.CrearPlantillaDataContract.PreguntasRespuestas,
                Nombre = request.CrearPlantillaDataContract.Nombre
            };

            string fileName = guid.ToString() + ".json";
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);

            var plantillaDTO = new PlantillaDTO
            {
                UriArchivo = fileName,
                Nombre = request.CrearPlantillaDataContract.Nombre
            };

            var plantilla = _mapper.Map<PlantillaDTO, Plantilla>(plantillaDTO);

            plantilla = await _plantillaRepository.Create(plantilla);

            return plantilla.Id;

        }
    }
}
