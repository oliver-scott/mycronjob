namespace MyCronJob.Job2
{
    public class Job2 : BackgroundService
    {
        private readonly ILogger<Job2> _logger;
        private readonly IHostApplicationLifetime _lifetime;

        public Job2(ILogger<Job2> logger, IHostApplicationLifetime lifetime)
        {
            _logger = logger;
            _lifetime = lifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Job 2 running at: {time}", DateTimeOffset.Now);
            
            await Task.Delay(45000, stoppingToken);

            _logger.LogInformation("Job 2 completed at: {time}", DateTimeOffset.Now);

            _logger.LogInformation("Stopping application");
            _lifetime.StopApplication();
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Stopping Job 2 at: {time}", DateTimeOffset.Now);
            await base.StopAsync(stoppingToken);
        }
    }   
}