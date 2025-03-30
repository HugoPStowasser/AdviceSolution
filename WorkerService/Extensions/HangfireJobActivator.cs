using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerService.Extensions;

public class HangfireJobActivator : JobActivator
{
    private readonly IServiceProvider _serviceProvider;

    public HangfireJobActivator(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public override object ActivateJob(Type jobType)
    {
        var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService(jobType);
    }
}