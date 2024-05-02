namespace EntityFramework.Entities
{
    public class ActorMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!; // FK -> Movie
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!; // FK -> Actor
        public string Character { get; set; } = null!;
        public int Order { get; set; }
    }
}
