using Domain.Entities.Orders;

namespace Application.Abstraction.Models.Invoice_DTOs
{
    public class InvoiceDto
    {   
        public int Id { get; set; }
        public int OrderId { get; set; } 
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
    }
}
