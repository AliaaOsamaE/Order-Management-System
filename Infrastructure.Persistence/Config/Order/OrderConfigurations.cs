using Domain.Entities.Orders;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Persistence._Data.Config.Orders
{
    internal class OrderConfigurations : BaseEntityConfigurations<Order, int>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(o => o.CustomerId)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                 .HasDefaultValueSql("GETDATE()");

            builder.Property(o => o.TotalAmount)
                 .HasColumnType("decimal(10,2)")
                 .IsRequired();


            builder.Property(order => order.status)
                .HasConversion
                (
                (OStatus) => OStatus.ToString(),
                (OStatus) => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                );

            builder.HasMany(order => order.orderItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(o => o.paymentMethod)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasMany(o => o.orderItems)
                   .WithOne(o => o.Order)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


