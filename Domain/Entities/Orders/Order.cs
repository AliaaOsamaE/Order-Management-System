using Domain.Common;
using Domain.Entities.Orders;
using System.Net;

namespace Domain.Entities.Orders
{
    public enum OrderStatus
    {
        Pending = 1,
        Received = 2,
        Failed = 3,
    }
    public enum PaymentMethod
    {
        CreditCard = 1,
        Cash = 2
    }
    public class Order: BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderItem> orderItems { get; set; } = new HashSet<OrderItem>();
        public OrderStatus status { get; set; } = OrderStatus.Pending;
        public PaymentMethod paymentMethod { get; set; } = PaymentMethod.CreditCard;
    }
}


