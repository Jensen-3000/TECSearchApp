namespace TECSearchApp.Logic.Services;

/// <summary>
/// Provides semester-based services including data retrieval and search functionality.
/// </summary>
public class SemesterService : ISemesterService
{
    private readonly IDataProvider _dataProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="SemesterService"/> class.
    /// </summary>
    /// <param name="dataProvider">The data provider to use for retrieving course data.</param>
    public SemesterService(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    /// <summary>
    /// Retrieves course data and converts it into a list of semesters.
    /// </summary>
    /// <returns>A list of semesters representing the retrieved course data.</returns>
    public List<Semester> GetCoursesFromData()
    {
        string[][] courseData = _dataProvider.GetCourseData();

        List<Semester> courses = new List<Semester>();

        for (int i = 0; i < courseData.Length; i++)
        {
            Semester course = new H1
            {
                CourseName = courseData[i][0],
                Teacher = new Teacher { FullName = courseData[i][1] },
                Students = new List<Student>()
            };

            for (int j = 2; j < courseData[i].Length; j++)
            {
                course.Students.Add(new Student { FullName = courseData[i][j] });
            }

            courses.Add(course);
        }

        return courses;
    }

    /// <summary>
    /// Searches for semesters based on the given search type and term.
    /// </summary>
    /// <param name="searchType">The type of search to perform.</param>
    /// <param name="searchTerm">The term to search for.</param>
    /// <returns>An enumeration of semesters matching the search criteria.</returns>
    public IEnumerable<Semester> Search(SearchType searchType, string searchTerm)
    {
        switch (searchType)
        {
            case SearchType.Lærer:
                return SearchTeacher(searchTerm);
            case SearchType.Elev:
                return SearchStudent(searchTerm);
            case SearchType.Fag:
                return SearchCourse(searchTerm);
            default:
                return Enumerable.Empty<Semester>();
        }
    }

    /// <summary>
    /// Searches for semesters based on the given search type and term.
    /// </summary>
    /// <param name="searchType">The type of search to perform.</param>
    /// <param name="searchTerm">The term to search for.</param>
    /// <returns>An enumeration of semesters matching the search criteria.</returns>
    public IEnumerable<Semester> SearchTeacher(string teacherName)
    {
        List<Semester> courses = GetCoursesFromData();
        return courses.Where(c => string.Equals(c.Teacher.FullName, teacherName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Searches for semesters by student name.
    /// </summary>
    /// <param name="studentName">The name of the student to search for.</param>
    /// <returns>An enumeration of semesters where the specified student is enrolled.</returns>
    public IEnumerable<Semester> SearchStudent(string studentName)
    {
        List<Semester> courses = GetCoursesFromData();
        return courses.Where(c => c.Students.Any(s => string.Equals(s.FullName, studentName, StringComparison.OrdinalIgnoreCase)));
    }

    /// <summary>
    /// Searches for semesters by course name.
    /// </summary>
    /// <param name="courseName">The name of the course to search for.</param>
    /// <returns>An enumeration of semesters where the specified course is taught.</returns>
    public IEnumerable<Semester> SearchCourse(string courseName)
    {
        List<Semester> courses = GetCoursesFromData();
        return courses.Where(c => string.Equals(c.CourseName, courseName, StringComparison.OrdinalIgnoreCase));
    }
}
