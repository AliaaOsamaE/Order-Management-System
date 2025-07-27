using Domain.Common;

namespace Domain.Entities.Orders
{
    public class Invoice:BaseEntity<int>
    {
        public int OrderId { get; set; } // FK to Order Entity
        public virtual Order? Order { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
    }
}
