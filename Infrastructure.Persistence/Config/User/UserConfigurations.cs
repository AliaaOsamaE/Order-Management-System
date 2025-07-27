using Domain.Entities.Users;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Config.Users
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

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256); 

            builder.Property(u => u.Role)
                   .HasConversion<int>()
                   .IsRequired();
        }
    }
}
