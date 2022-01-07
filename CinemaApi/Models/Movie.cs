using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CinemaApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El idioma es requerido")]
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
        public ICollection<Reservation> Reservations { get; set; }

    }
}
