using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        //useing anotations to define the column name and the required field
        //[Required]
        //[StringLength(255)]
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>(); // Navigation property -> foreign key
    }
}
