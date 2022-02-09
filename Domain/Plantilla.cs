using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Plantilla : BaseDomainEntity
    {
        public string Nombre { get; set; }

        public string UriArchivo { get; set; }
    }
}
