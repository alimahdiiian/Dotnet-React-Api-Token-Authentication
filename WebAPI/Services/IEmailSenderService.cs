namespace WebAPI.Services
{
    public interface IEmailSenderService
    {
        string SendEmail(string email);
    }
}
