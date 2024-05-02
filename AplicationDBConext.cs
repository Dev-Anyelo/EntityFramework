using EntityFramework.Entities;
using EntityFramework.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityFramework
{
    public class AplicationDBConext : DbContext
    {
        public AplicationDBConext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This apply all configurations from the assembly 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // This is used to seed the database
            InitialSeeding.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            // useing conventions to configure data.
            configurationBuilder.Properties<string>().HaveMaxLength(255);
        }
        // Add the DbSet for each entity
        // Tables in the database
        public DbSet<Gender> Genders => Set <Gender>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<ActorMovie> ActorsMovies => Set<ActorMovie>();
    }
}
