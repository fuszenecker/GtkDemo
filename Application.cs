using Gtk;

namespace svc01;

public class MyApplication
{
    private readonly ILogger<MyApplication> logger;
    private readonly IServiceProvider services;
    public Application App { get; init; }

    public MyApplication(ILogger<MyApplication> logger, IServiceProvider services)
    {
        this.services = services;
        this.logger = logger;
        logger.LogInformation("Initializing application");
        Application.Init();

        var app = new Application("org.gtk01.gtk01", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        this.App = app;
    }

    public void Initialize()
    {
        logger.LogInformation("Opening MainWindow");
        var win = services.GetService<MainWindow>();
        this.App.AddWindow(win);

        logger.LogInformation("Showing Mainwindow");
        win?.Show();

        logger.LogInformation("Running application");
   }
}