using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entrevista : BaseDomainEntity
    {
        public string Entrevistado { get; set; }
        public string Entrevistador { get; set; }
        public string UriArchivo { get; set; }

    }
}
