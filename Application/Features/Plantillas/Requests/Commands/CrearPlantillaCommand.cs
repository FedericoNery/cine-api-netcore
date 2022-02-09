using Application.DTO_s.Plantilla;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Plantillas.Requests.Commands
{
    public class CrearPlantillaCommand : IRequest<int>
    {
        public CrearPlantillaDataContract CrearPlantillaDataContract { get; set; }
    }
}
