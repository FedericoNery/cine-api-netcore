using Application.Persistence;
using Domain;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PlantillaRepository : GenericRepository<Plantilla>, IPlantillaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public PlantillaRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
