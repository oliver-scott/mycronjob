namespace MyCronJob.Job2
{
    public class Job2 : BaseService
    {
        private readonly ILogger<Job2> _logger;

        public Job2(ILogger<Job2> logger, IHostApplicationLifetime lifetime) : base(lifetime)
        {
            _logger = logger;
        }

        protected override async Task DoWorkAsync()
        {
            _logger.LogInformation("Job 2 running at: {time}", DateTimeOffset.Now);
            
            await Task.Delay(45000);

            _logger.LogInformation("Job 2 completed at: {time}", DateTimeOffset.Now);
        }
    }   
}