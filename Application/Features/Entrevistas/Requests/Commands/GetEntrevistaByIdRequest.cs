using Application.DTO_s.Entrevista;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Entrevistas.Requests.Commands
{
    public class GetEntrevistaByIdRequest : IRequest<EntrevistaFile> //Debería devolver el objeto
    {
        public int Id { get; set; }
    }
}
