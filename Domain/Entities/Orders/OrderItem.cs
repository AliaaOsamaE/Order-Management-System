using Domain.Common;
using Domain.Entities.Products;
namespace Domain.Entities.Orders
{
    public class OrderItem : BaseEntity<int>
    {
        public int OrderId { get; set; } // FK to Order Entity
        public virtual Order? Order { get; set; }

        public int ProductId { get; set; } // FK to Product Entity
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; } = 0.0M;
    }
}
