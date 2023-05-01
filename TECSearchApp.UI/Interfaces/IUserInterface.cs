namespace TECSearchApp.UI.Interfaces;

public interface IUserInterface
{
    int GetSearchType();
    string GetSearchTerm(SearchType searchType);
    void DisplayCourses(IEnumerable<Semester> courses, bool hasResults, SearchType searchType);
    void DisplayInvalidInputMessage();
    void DisplayAvailableCourses(IEnumerable<Semester> semesters);
}
