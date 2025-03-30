using Application.Interfaces;
using Hangfire;
using Hangfire.SqlServer;
using HangfireJobs;
using Infrastructure;
using WorkerService.Extensions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddInfrastructure(context.Configuration);
        services.AddScoped<IAdviceService, Infrastructure.Services.AdviceService>();
        services.AddTransient<AdviceUpsertJob>();

        services.AddHangfire((provider, config) =>
        {
            config.UseSqlServerStorage(
                context.Configuration.GetConnectionString("HangfireConnection"),
                new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    PrepareSchemaIfNecessary = true
                })
                .UseActivator(new HangfireJobActivator(provider));
        });

        services.AddHangfireServer();
    })
    .Build();

using var scope = host.Services.CreateScope();
var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate<AdviceUpsertJob>(
    "advice-upsert-job",
    job => job.ExecuteAsync(),
    Cron.Hourly
);

host.Run();