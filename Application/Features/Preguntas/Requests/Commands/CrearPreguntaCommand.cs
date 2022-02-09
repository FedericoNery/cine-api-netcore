using Application.DataContract.Preguntas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Preguntas.Requests.Commands
{
    public class CrearPreguntaCommand : IRequest<int>
    {
        public CrearPreguntaDataContract CrearPreguntaDataContract { get; set; }
    }
}
