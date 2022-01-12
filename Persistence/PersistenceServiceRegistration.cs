using Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            /* 
             * AGREGAR CONNECTION STRING
             * services.AddDbContext<CinemaDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDb;Integrated Security = True")));*/

            services.AddDbContext<CinemaDbContext>(option =>
            option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CinemaDb;Integrated Security = True"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
