using Domain.Entities.Orders;
using Infrastructure.Persistence.Data.Config.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Data.Config.OrderConfigurations
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


            builder.Property(order => order.Status)
                .HasConversion
                (
                (OStatus) => OStatus.ToString(),
                (OStatus) => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                );

            builder.HasMany(order => order.OrderItems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(o => o.PaymentMethod)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasMany(o => o.OrderItems)
                   .WithOne(o=> o.Order)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


