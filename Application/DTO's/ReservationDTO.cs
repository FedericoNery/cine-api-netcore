using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class ReservationDTO : BaseDTO
    {
        public int Qty { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationTime { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public MovieDTO Movie { get; set; }

        public UserDTO User { get; set; }
    }
}
