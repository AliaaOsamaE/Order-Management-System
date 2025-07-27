using Domain.Entities.Orders;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Config.Orders
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
