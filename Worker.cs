using Gtk;

namespace svc01;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly MyApplication application;

    public Worker(ILogger<Worker> logger, MyApplication application)
    {
        this.logger = logger;
        this.application = application;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Task.Run(() =>
        {
            application.Initialize();
            this.logger.LogInformation("Running application");
            Application.Run();
        }, stoppingToken);
    }
}
