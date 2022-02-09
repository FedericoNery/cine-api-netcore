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
    public class PreguntaRepository : GenericRepository<PreguntaRespuesta>, IPreguntasRepository
    {
        private readonly CinemaDbContext _dbContext;

        public PreguntaRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
