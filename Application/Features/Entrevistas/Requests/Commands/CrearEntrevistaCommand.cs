using Application.DTO_s.Entrevista;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Entrevistas.Requests.Commands
{
    public class CrearEntrevistaCommand : IRequest<int>
    {
        public CrearEntrevistaDataContract CrearEntrevistaDataContract { get; set; }
    }
}
