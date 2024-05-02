using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EntityFramework.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            // useing Fluent API to configure data.
            builder.Property(a => a.Birthdate).HasColumnType("date");
            builder.Property(a => a.Salary).HasPrecision(18, 2); // => 18 digits, 2 decimal places.
        }
    }
}
