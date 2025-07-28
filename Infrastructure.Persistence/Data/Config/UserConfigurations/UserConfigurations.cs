using Domain.Entities.Users;
using Infrastructure.Persistence.Data.Config.BaseConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Config.UserConfigurations
{
    internal class UserConfigurations : BaseEntityConfigurations<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(u => u.Username)
                   .IsUnique();

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.Role)
                   .HasConversion<int>()
                   .IsRequired();
        }
    }
}
