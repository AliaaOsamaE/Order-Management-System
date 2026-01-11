using Application.Abstraction.Models.Invoice_DTOs;
using Domain.Entities.Orders;
namespace Application.Abstraction.Services._Invoice
{
    public interface IInvoiceService
    {
        public Task<InvoiceDto> GetInvoiceDetails(int invoiceId);
        public Task<IEnumerable<InvoiceDto>> GetAllInvoices();
    }
}
