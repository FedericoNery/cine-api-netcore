using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s.Entrevista
{
    public class EntrevistaFile
    {
        public EntrevistaFile()
        {
            Preguntas = new List<PreguntaRespuestaEntrevistaFile>();
        }

        public string Entrevistador { get; set; }
        public string Entrevistado { get; set; }
        public List<PreguntaRespuestaEntrevistaFile> Preguntas { get; set; }
    }

    public class PreguntaRespuestaEntrevistaFile
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public string RespuestaCorrecta { get; set; }

    }
}
