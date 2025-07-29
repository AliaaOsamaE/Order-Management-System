using Application.Abstraction.Services.Shared;
using Domain.Entities.Customers;
using Domain.Entities.Orders;
using Domain.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;

namespace Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork unitOfWork;

        public EmailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task SendEmail(int orderId)
        {
            var order = await unitOfWork.GetRepository<Order, int>().GetAsync(orderId);
            if (order is null)
            {
                throw new NotFoundException($"Order not found");
            }
            var customer = await unitOfWork.GetRepository<Customer, int>().GetAsync(order.CustomerId);
            if (customer is null)
            {
                throw new NotFoundException($"Customer not found");
            }
            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new NotFoundException($"Customer does not have a email");
            }

            var to = customer.Email;
            var emailBody = $"The status of your order (ID: {orderId}) has been updated.";

            Console.WriteLine($"Email sent to: {to}");
            Console.WriteLine($"Body: {emailBody}");
        }
    }
}