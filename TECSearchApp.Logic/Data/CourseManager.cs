namespace TECSearchApp.Logic.Data;

public class CourseManager : ICourseManager
{
    private ICourseDataLoader dataLoader;
    private ICourseSearch courseSearch;

    public CourseManager(ICourseDataLoader dataLoader, ICourseSearch courseSearch)
    {
        this.dataLoader = dataLoader;
        this.courseSearch = courseSearch;
    }

    public void LoadData(string[][] data)
    {
        var courses = dataLoader.LoadCourses(data);
        courseSearch.SetCourses(courses);
    }

    public List<Course> SearchByCourseName(string courseName)
    {
        return courseSearch.SearchByCourseName(courseName);
    }

    public List<Course> SearchByTeacherName(string teacherName)
    {
        return courseSearch.SearchByTeacherName(teacherName);
    }

    public List<Course> SearchByStudentName(string studentName)
    {
        return courseSearch.SearchByStudentName(studentName);
    }

    public List<string> GetCourseNames()
    {
        return courseSearch.GetCourseNames();
    }
}
