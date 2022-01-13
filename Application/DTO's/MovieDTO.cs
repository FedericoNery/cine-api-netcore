using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.DTO_s
{
    public class MovieDTO : BaseDTO //se crean los dtos especificos
    {
        public string Name { get; set; }
        public string Language { get; set; }

        public string Description { get; set; }
        public string Duration { get; set; }
        public DateTime PlayingDate { get; set; }
        public DateTime PlayingTime { get; set; }
        public double TicketPrice { get; set; }
        public double Rating { get; set; }
        public string Genre { get; set; }
        public string TrailorUrl { get; set; }
        public string ImageUrl { get; set; }
        [XmlIgnore]
        [Ignore]
        public IList<ReservationDTO> Reservations { get; set; }
    }
}
