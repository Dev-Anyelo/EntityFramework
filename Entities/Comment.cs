namespace EntityFramework.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; } = null!;
        public bool IsApproved { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!; // Navigation property -> foreign key 
    }
}

