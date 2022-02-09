using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PreguntaRespuesta : BaseDomainEntity
    {
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public string RespuestaCorrecta { get; set; }
    }
}
