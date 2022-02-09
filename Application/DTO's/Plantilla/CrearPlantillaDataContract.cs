using Application.DTO_s.Pregunta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Plantilla
{
    public class CrearPlantillaDataContract
    {
        public string Nombre { set; get; }
        public List<int> PreguntasRespuestas { get; set; }
    }
}
