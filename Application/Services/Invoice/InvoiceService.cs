using Application.Abstraction.Models.Invoice_DTOs;
using Application.Abstraction.Services._Invoice;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;

namespace Application.Services._Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
        {
            var invoices = await _unitOfWork.GetRepository<Invoice, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto> GetInvoiceDetails(int invoiceId)
        {
            var invoice = await _unitOfWork.GetRepository<Invoice, int>().GetAsync(invoiceId);
            if (invoice is null) throw new NotFoundException("Invoice not found");
            return _mapper.Map<InvoiceDto>(invoice);
        }
    }
}
