using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework.Entities.Configurations
{
    public class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            var scienceFiction = new Gender { Id = 5, Name = "Science Fiction" };
            var animation = new Gender { Id = 6, Name = "Animation" };

            builder.HasData(scienceFiction, animation);

            builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
