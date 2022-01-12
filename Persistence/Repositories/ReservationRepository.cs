using Application.Persistence;
using Domain;
using Persistence.Data;

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
