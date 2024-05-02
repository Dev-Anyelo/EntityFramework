using System.ComponentModel.DataAnnotations;

namespace EntityFramework.DTOs
{
    public class CreationActorDTO
    {
        [StringLength (150)]
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
