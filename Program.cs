using svc01;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<MainWindow>();
        services.AddTransient<MyApplication>();
    })
    .Build();

await host.RunAsync();
