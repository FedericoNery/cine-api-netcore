using Application.DTO_s.Entrevista;
using Application.Features.Entrevistas.Requests.Commands;
using Application.Persistence;
using AutoMapper;
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
    public class GetEntrevistaByIdRequestHandler : IRequestHandler<GetEntrevistaByIdRequest, EntrevistaFile>
    {
        private readonly IEntrevistaRepository _entrevistaRepository;
        private readonly IPlantillaRepository _plantillaRepository;
        private readonly IMapper _mapper;

        public GetEntrevistaByIdRequestHandler(
            IEntrevistaRepository entrevistaRepository,
            IPlantillaRepository plantillaRepository,
            IMapper mapper)
        {
            _entrevistaRepository = entrevistaRepository;
            _plantillaRepository = plantillaRepository;
            _mapper = mapper;
        }

        public async Task<EntrevistaFile> Handle(GetEntrevistaByIdRequest request, CancellationToken cancellationToken)
        {
            //var validator = new CreateMovieDTOValidator();
            //var validationResult = await validator.ValidateAsync(request.CreateMovieDTO);

            //if (validationResult.IsValid == false)
            //  throw new ValidationException(validationResult);


            var entrevista = await _entrevistaRepository.Get(request.Id);
            var plantilla = await _plantillaRepository.Get(entrevista.Id);
            var fileName = entrevista.UriArchivo;
            using FileStream openStream = File.OpenRead(fileName);
            var weatherForecast =
                await JsonSerializer.DeserializeAsync<EntrevistaFile>(openStream);

            return weatherForecast;
        }
    }
}
