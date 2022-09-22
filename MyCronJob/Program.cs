using MyCronJob.Job1;
using MyCronJob.Job2;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        if (args.Contains("Job1"))
        {
            services.AddHostedService<Job1>();
        }

        if (args.Contains("Job2"))
        {
            services.AddHostedService<Job2>();
        }
    })
    .Build();
    
await host.RunAsync();