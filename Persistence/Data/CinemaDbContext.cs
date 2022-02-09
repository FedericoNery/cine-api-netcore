using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext (DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PreguntaRespuesta> PreguntasRespuestas { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Entrevista> Entrevistas { get; set; }
    }
}
