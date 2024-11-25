namespace Sol_Demos.Services;

public interface IWorkerDemo
{
    Task HandleAsync(CancellationToken cancellationToken);
}

public class WorkerDemo : IWorkerDemo
{
    private readonly ILogger<WorkerDemo> _logger;

    public WorkerDemo(ILogger<WorkerDemo> logger)
    {
        _logger = logger;
    }

    public Task HandleAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Worker Demo Service is Running.");
        return Task.CompletedTask;
    }
}