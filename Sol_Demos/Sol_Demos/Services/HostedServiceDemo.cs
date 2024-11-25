namespace Sol_Demos.Services;

public class HostedServiceDemo : IHostedService, IDisposable
{
    private readonly ILogger<HostedServiceDemo> _logger;
    private readonly IWorkerDemo _workerDemo;
    private Timer? _timer;

    public HostedServiceDemo(ILogger<HostedServiceDemo> logger, IWorkerDemo workerDemo)
    {
        _logger = logger;
        _workerDemo = workerDemo;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        //while (!cancellationToken.IsCancellationRequested)
        //{
        //    await _workerDemo.HandleAsync(cancellationToken);

        //    // Simulate some background work
        //    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        //}

        _timer = new Timer(async (state) =>
        {
            await _workerDemo.HandleAsync(cancellationToken);
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }
}