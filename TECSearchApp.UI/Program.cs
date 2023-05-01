IServiceProvider serviceProvider;
try
{
    // Create a new ServiceCollection and register required dependencies
    serviceProvider = new ServiceCollection()
        .AddSingleton<IDataProvider, DefaultDataProvider>() // TestCourseDataProvider | DefaultCourseDataProvider
        .AddSingleton<ISemesterService, SemesterService>()
        .AddSingleton<IUserInterface, ConsoleUserInterface>()
        .AddTransient<App>()
        .BuildServiceProvider();
}
catch (Exception ex)
{
    // Catch any exceptions that may occur during the creation of the service provider
    Console.WriteLine($"Der skete en fejl: {ex.Message}");
    return;
}

// Get the App service from the service provider and run it
serviceProvider.GetService<App>().Run();
