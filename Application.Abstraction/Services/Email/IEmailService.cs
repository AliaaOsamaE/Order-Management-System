namespace Application.Abstraction.Services.Shared
{
    public interface IEmailService
    {
        Task SendEmail(int orderId);
    }
}
