using Application.Persistence;
using CinemaApi.Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly CinemaDbContext _dbContext;

        public ReservationRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
