using Application.DTO_s.Entrevista;
using Application.Features.Entrevistas.Requests.Commands;
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

namespace Application.Features.Entrevistas.Handlers.Commands
{
    public class CrearEntrevistaCommandHandler : IRequestHandler<CrearEntrevistaCommand, int>
    {
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly IPlantillaRepository _plantillaRepository;
        private readonly IPreguntasRepository _preguntaRepository;
        private readonly IMapper _mapper;

        public CrearEntrevistaCommandHandler(
            IEntrevistaRepository entrevistaRepository,
            IPlantillaRepository plantillaRepository,
            IPreguntasRepository preguntaRepository,
            IMapper mapper)
        {
            _entrevistaRepository = entrevistaRepository;
            _preguntaRepository = preguntaRepository;
            _plantillaRepository = plantillaRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearEntrevistaCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateMovieDTOValidator();
            //var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);

            //if (validationResult.IsValid == false)
            //  throw new ValidationException(validationResult);

            var entrevistaJson = new EntrevistaFile();

            var plantilla = await _plantillaRepository.Get(request.CrearEntrevistaDataContract.IdPlantilla);

            var fileName = plantilla.UriArchivo;
            using FileStream openStream = File.OpenRead(fileName);
            var weatherForecast =
                await JsonSerializer.DeserializeAsync<EntrevistaJson>(openStream);

            var listaPreguntas = weatherForecast.Preguntas;
            //Asigno las props de EntrevistaFile
            entrevistaJson.Entrevistado = request.CrearEntrevistaDataContract.Entrevistado;
            entrevistaJson.Entrevistador = request.CrearEntrevistaDataContract.Entrevistador;

            for (int i = 0; i < listaPreguntas.Count; i++)
            {
                var pregunta = await _preguntaRepository.Get(listaPreguntas[i]);
                entrevistaJson.Preguntas.Add(new PreguntaRespuestaEntrevistaFile
                {
                    Id = pregunta.Id, 
                    Pregunta = pregunta.Pregunta,
                    Respuesta = pregunta.Respuesta,
                    RespuestaCorrecta = pregunta.RespuestaCorrecta,
                });
            }

            //Guardar Entrevista json
            Guid guid = Guid.NewGuid();
            string newFileName = guid.ToString() + ".json";
            try
            {
                string jsonString = JsonSerializer.Serialize(entrevistaJson);
                File.WriteAllText(newFileName, jsonString);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }

            var entrevistaDTO = new EntrevistaDTO
            {
                Entrevistado = request.CrearEntrevistaDataContract.Entrevistado,
                Entrevistador = request.CrearEntrevistaDataContract.Entrevistador,
                UriArchivo = newFileName
            };

            var entrevista = _mapper.Map<EntrevistaDTO, Entrevista>(entrevistaDTO);

            entrevista = await _entrevistaRepository.Create(entrevista);

            return entrevista.Id;
        }
    }
}
