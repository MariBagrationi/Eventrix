using Eventrix.App.Services;

namespace Eventrix.WorkerService
{
    public class EmailWorker : BackgroundService
    {
        private readonly IEmailQueue _queue;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<EmailWorker> _logger;

        public EmailWorker(IEmailQueue queue, ILogger<EmailWorker> logger, IEmailSender emailSender)
        {
            _queue = queue;
            _logger = logger;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var job = await _queue.DequeueAsync(stoppingToken);
                if (job != null)
                {
                    await _emailSender.SendVerificationEmailAsync(job.Email, job.Code, stoppingToken);
                }

                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
