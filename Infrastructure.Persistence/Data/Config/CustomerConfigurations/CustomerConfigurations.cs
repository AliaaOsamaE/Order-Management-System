using Domain.Entities.Customers;
using Infrastructure.Persistence.Data.Config.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Config.CustomerConfigurations
{
    internal class CustomerConfigurations : BaseEntityConfigurations<Customer, int>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(c => c.Email)
                   .IsUnique();

            builder.HasMany(c => c.Orders)
                   .WithOne()
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
