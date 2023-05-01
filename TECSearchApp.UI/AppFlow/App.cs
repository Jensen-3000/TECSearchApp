namespace TECSearchApp.UI.AppFlow;

/// <summary>
/// Implements the main application logic for TECSearchApp.
/// </summary>
public class App
{
    private readonly ISemesterService _courseService;
    private readonly IUserInterface _userInterface;

    public App(ISemesterService courseService, IUserInterface userInterface)
    {
        _courseService = courseService;
        _userInterface = userInterface;
    }

    /// <summary>
    /// Runs the main application loop.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            int searchType = _userInterface.GetSearchType();

            if (searchType >= 1 && searchType <= 3)
            {
                string searchTerm = _userInterface.GetSearchTerm();

                // Validate search term
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    _userInterface.DisplayInvalidInputMessage();
                    continue; // continue the while loop
                }

                IEnumerable<Semester> courses = _courseService.Search((SearchType)searchType, searchTerm);
                bool hasResults = courses.Any();
                _userInterface.DisplayCourses(courses, hasResults);
            }
            else
            {
                _userInterface.DisplayInvalidInputMessage();
            }
        }
    }
}
