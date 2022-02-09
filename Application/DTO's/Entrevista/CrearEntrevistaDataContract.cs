using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Entrevista
{
    public class CrearEntrevistaDataContract
    {
        public string Entrevistado { get; set; }
        public string Entrevistador { get; set; }
        public int IdPlantilla { get; set; }
    }
}
