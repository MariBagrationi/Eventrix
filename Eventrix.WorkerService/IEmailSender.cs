namespace Eventrix.WorkerService
{
    public interface IEmailSender
    {
        Task SendVerificationEmailAsync(string toEmail, string code, CancellationToken cancellationToken);
    }
}
