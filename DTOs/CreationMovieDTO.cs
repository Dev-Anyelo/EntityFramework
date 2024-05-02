using EntityFramework.Entities;

namespace EntityFramework.DTOs
{
    public class CreationMovieDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public bool InTheaters { get; set; }

        // int because we are going to recive the id
        public List<int> Genders{ get; set; } = new List<int>();    
        public List<CreationMovieActorDTO> MoviesActors { get; set; } = new List<CreationMovieActorDTO>();
     }
}
