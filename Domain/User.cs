﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class User: BaseDomainEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [XmlIgnore]
        public ICollection<Reservation> Reservations { get; set; }
    }
}