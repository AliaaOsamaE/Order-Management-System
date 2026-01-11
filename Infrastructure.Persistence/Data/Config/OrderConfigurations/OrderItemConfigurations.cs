using Domain.Entities.Orders;
using Infrastructure.Persistence.Data.Config.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Config.OrderConfigurations
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
                   .WithMany(o => o.OrderItems)
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
