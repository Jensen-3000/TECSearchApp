namespace TECSearchApp.UI.AppFlow;

/// <summary>
/// Implements the main application logic for TECSearchApp.
/// </summary>
public class App
{
    private readonly ISemesterService _courseService;
    private readonly IUserInterface _userInterface;
    private readonly IEnumerable<Semester> _allCouses;

    public App(ISemesterService courseService, IUserInterface userInterface)
    {
        _courseService = courseService;
        _userInterface = userInterface;
        _allCouses = _courseService.GetCoursesFromData();
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
                // If search type is 3 (for courses), display available courses first
                if (searchType == 3)
                {
                    _userInterface.DisplayAvailableCourses(_allCouses);
                }

                // Validate search term
                string searchTerm = _userInterface.GetSearchTerm((SearchType)searchType);
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    _userInterface.DisplayInvalidInputMessage();
                    continue; // continue the while loop
                }

                IEnumerable<Semester> courses = _courseService.Search((SearchType)searchType, searchTerm);
                bool hasResults = courses.Any();
                _userInterface.DisplayCourses(courses, hasResults, (SearchType)searchType);
            }
            else
            {
                _userInterface.DisplayInvalidInputMessage();
            }
        }
    }
}
