IServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<IDataProvider, DefaultDataProvider>() // TestDataProvider | DefaultDataProvider, Could be data from other H1, H2
    .AddSingleton<ICourseDataLoader, CourseDataLoader>()
    .AddSingleton<ICourseSearch, CourseSearch>()
    .AddSingleton<ICourseManager, CourseManager>()
    .AddSingleton<UserInterface>()
    .BuildServiceProvider();

IDataProvider? dataProvider = serviceProvider.GetService<IDataProvider>();
string[][] courseData = dataProvider.GetCourseData();

ICourseManager? courseManager = serviceProvider.GetService<ICourseManager>();
courseManager.LoadData(courseData);

UserInterface? userInterface = serviceProvider.GetService<UserInterface>();
userInterface.RunMenuLoop();