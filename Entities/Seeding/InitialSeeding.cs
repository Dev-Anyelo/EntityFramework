using Microsoft.EntityFrameworkCore;


namespace EntityFramework.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //add data actor to the database//
            var adanSamdler = new Actor() { Id = 2, Name = "Adan Sandler", Salary = 1200, Birthdate = new DateTime(1966, 9, 9) };
            var kevinJames = new Actor() { Id = 3, Name = "Kevin James", Salary = 1200, Birthdate = new DateTime(1965, 4, 26) };

            modelBuilder.Entity<Actor>().HasData(adanSamdler, kevinJames);

            //add data movie to the database//
            var avengers = new Movie() { Id = 4, Title = "Avengers", Description = "ABCDE", ReleaseDate = new DateTime(2012, 5, 4), InTheaters = true };
            var theNotebook = new Movie() { Id = 5, Title = "The Notebook", Description = "ABCDE", ReleaseDate = new DateTime(2004, 6, 25), InTheaters = true };
            var mrAndMrsSmith = new Movie() { Id = 6, Title = "Mr. & Mrs. Smith", Description = "ABCDE", ReleaseDate = new DateTime(2005, 6, 10), InTheaters = true };

            modelBuilder.Entity<Movie>().HasData(avengers, theNotebook, mrAndMrsSmith);

            //add data comment to the database//
            var commentAvengers = new Comment() { Id = 3, Content = "The best movie ever", IsApproved = true, MovieId = avengers.Id };
            var commentTheNotebook = new Comment() { Id = 4, Content = "I cried a lot", IsApproved = false, MovieId = theNotebook.Id, };
            var commentMrAndMrsSmith = new Comment() { Id = 5, Content = "I love this movie", IsApproved = true, MovieId = mrAndMrsSmith.Id };

            modelBuilder.Entity<Comment>().HasData(commentAvengers, commentTheNotebook, commentMrAndMrsSmith);


            // many to many relationship within intermediate table, 
            // we need the exact name of the table and the properties of the table
            var tableGenderMovie = "GenderMovie";
            var GenderIdProperty = "GendersId";
            var MovieIdProperty = "MoviesId";

            var scienceFiction = 5;
            var animation = 6;

            // there is not a intermediate table entity, 
            //so we need to add the data manually  with a dictionary
            modelBuilder.Entity(tableGenderMovie).HasData(
                new Dictionary<string, object>
                {
                    [GenderIdProperty] = scienceFiction,
                    [MovieIdProperty] = avengers.Id
                },

                new Dictionary<string, object>
                {
                    [GenderIdProperty] = animation,
                    [MovieIdProperty] = mrAndMrsSmith.Id
                }
            );

            // many to many relationship with intermediate table
            var adanSamdlerMrAndMrsSmith = new ActorMovie
            {
                ActorId = adanSamdler.Id,
                MovieId = mrAndMrsSmith.Id,
                Character = "John Smith",
                Order = 1
            };

            var kevinJamesTheNoteBook = new ActorMovie
            {
                ActorId = kevinJames.Id,
                MovieId = theNotebook.Id,
                Character = "El loco",
                Order = 2
            };

            modelBuilder.Entity<ActorMovie>()
                .HasData(
                    adanSamdlerMrAndMrsSmith,
                    kevinJamesTheNoteBook
                );
        }
    }
}
