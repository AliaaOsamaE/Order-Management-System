using Domain.Entities.Orders;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Config.Orders
{
    internal class OrderItemConfigurations : BaseEntityConfigurations<OrderItem, int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.HasOne(o => o.Product)
                   .WithMany()
                   .HasForeignKey(o => o.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Order)
                   .WithMany(o => o.orderItems)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.UnitPrice)
                  .HasColumnType("decimal(10,2)");

            builder.Property(o => o.Discount)
                 .HasColumnType("decimal(10,2)");

            builder.Property(o => o.Quantity)
                   .IsRequired();
        }
    }
}
