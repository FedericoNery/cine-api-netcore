using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Reservation : BaseDomainEntity
    {
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationTime { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        //Ver como Entity puede llegar a mapear la entidad segun el id que le coloqué en el model así no tengo que queryar
        [NotMapped]
        public Movie Movie { get; set; }

        [NotMapped]
        public User User { get; set; }

    }
}
