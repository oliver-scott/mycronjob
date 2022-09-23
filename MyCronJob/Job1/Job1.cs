namespace MyCronJob.Job1
{
    public class Job1 : BaseService
    {
        private readonly ILogger<Job1> _logger;

        public Job1(ILogger<Job1> logger, IHostApplicationLifetime lifetime) : base(lifetime)
        {
            _logger = logger;
        }

        protected override async Task DoWorkAsync()
        {
            _logger.LogInformation("Job 1 running at: {time}", DateTimeOffset.Now);
            
            await Task.Delay(30000);
            
            throw new InvalidOperationException(); // Test - throw an exception to see how errors are handled
        }
    }   
}