using Domain.Common;
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
        PayPal = 2,
        Cash = 3
    }
    public class Order: BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CreditCard;
    }
}


