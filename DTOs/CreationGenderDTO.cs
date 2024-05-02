using System.ComponentModel.DataAnnotations;

namespace EntityFramework.DTOs
{
    public class CreationGenderDTO
    {
        [StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;
    }
}
