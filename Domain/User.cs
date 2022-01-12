using System.Collections.Generic;
using System.Text.Json;
namespace Domain
{
    public class User: BaseDomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        //[XmlIgnore]
        //public IList<Reservation> Reservations { get; set; }
    }
}
