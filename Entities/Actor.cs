namespace EntityFramework.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateTime Birthdate { get; set; }
        public List<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>(); // Navigation property -> foreign key
    }
}
