using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Domain
{
    public class Movie : BaseDomainEntity
    {
        public Movie()
        {

        }
        /*
        public Movie(string name, string language, string description, string duration, DateTime playingDate, DateTime playingTime,
            double ticketPrice, double rating, string genre, string trailorUrl, string imageUrl)
        {
            Name = name;
            Language = language;
            Description = description;
            Duration = duration;
            PlayingDate = playingDate;
            PlayingTime = playingTime;
            TicketPrice = ticketPrice;
            Rating = rating;
            Genre = genre;
            TrailorUrl = trailorUrl;
            ImageUrl = imageUrl;
        }*/

        [Required(ErrorMessage = "El Nombre es requerido")]
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
        public IList<Reservation> Reservations { get; set; }

    }
}
