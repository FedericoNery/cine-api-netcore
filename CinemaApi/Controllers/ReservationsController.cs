using CinemaApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CinemaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private CinemaDbContext _dbContext;
        public ReservationsController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*[HttpPost]
        [Authorize]
        public IActionResult ReserveTicket([FromBody] Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }*/

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult GetReservations()
        {
            var reservations = _dbContext.Reservations.ToList();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetReservationDetail(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            if (reservation == null)
                return StatusCode(StatusCodes.Status404NotFound);
            else
                return Ok(reservation);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            if (reservation == null)
                return StatusCode(StatusCodes.Status404NotFound);
            else
            {
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
                return Ok(reservation);
            }
        }
    }
}
