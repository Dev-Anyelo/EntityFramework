namespace EntityFramework.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public bool InTheaters { get; set; }
        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>(); // Navigation property -> foreign key 
        public HashSet<Gender> Genders { get; set; } = new HashSet<Gender>(); // Navigation property -> foreign key
        public List<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>(); // Navigation property -> foreign key
    }
}
