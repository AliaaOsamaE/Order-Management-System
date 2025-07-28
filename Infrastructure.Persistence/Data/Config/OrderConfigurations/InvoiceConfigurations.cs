using Domain.Entities.Orders;
using Infrastructure.Persistence.Data.Config.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Config.Order
{
    internal class InvoiceConfigurations : BaseEntityConfigurations<Invoice, int>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.OrderId)
                   .IsRequired();

            builder.HasOne(i => i.Order)
                   .WithOne()
                   .HasForeignKey<Invoice>(i => i.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.InvoiceDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(i => i.TotalAmount)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();
        }
    }
}
