using Application.Persistence;
using Domain;
using Persistence.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly CinemaDbContext _dbContext;

        public UserRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /*public async Task<List<User>> GetAll(){
            return await base.GetAll();
        }*/
    }
}
