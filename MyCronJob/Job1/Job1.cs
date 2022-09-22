namespace MyCronJob.Job1
{
    public class Job1 : BackgroundService
    {
        private readonly ILogger<Job1> _logger;
        private readonly IHostApplicationLifetime _lifetime;

        public Job1(ILogger<Job1> logger, IHostApplicationLifetime lifetime)
        {
            _logger = logger;
            _lifetime = lifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Job 1 running at: {time}", DateTimeOffset.Now);
            
                await Task.Delay(30000, stoppingToken);

                throw new InvalidOperationException(); // Test - throw an exception to see how errors are handled

                _logger.LogInformation("Job 1 completed at: {time}", DateTimeOffset.Now);

                _logger.LogInformation("Stopping application");
                _lifetime.StopApplication();
            }
            catch (Exception)
            {
                // Signal to the OS that this was an error condition
                // Indicates to Kubernetes that the job has failed
                Environment.ExitCode = 1;
                throw;
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Stopping Job 1 at: {time}", DateTimeOffset.Now);
            await base.StopAsync(stoppingToken);
        }
    }   
}