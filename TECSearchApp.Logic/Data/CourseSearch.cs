namespace TECSearchApp.Logic.Data;

public class CourseSearch : ICourseSearch
{
    private List<Course> courses;

    public CourseSearch()
    {
        courses = new List<Course>();
    }

    public void SetCourses(List<Course> courses)
    {
        this.courses = courses;
    }

    public List<Course> SearchByCourseName(string courseName)
    {
        // Returns the list of courses that match the courseName
        return courses.Where(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Course> SearchByTeacherName(string teacherName)
    {
        // Returns the list of courses taught by the teacher with the given teacherName
        return courses
            .Where(c => c.Teacher.FullName.Equals(teacherName, StringComparison.OrdinalIgnoreCase))
            .OrderBy(c => c.Name) // Order the courses by their names
            .ToList();
    }

    public List<Course> SearchByStudentName(string studentName)
    {
        // Returns the list of courses that the student with the given studentName is attending
        return courses
            .Where(c => c.Students.Any(s => s.FullName.Equals(studentName, StringComparison.OrdinalIgnoreCase)))
            .Select(c => new Course
            {
                Name = c.Name,
                Teacher = c.Teacher,
                Students = new List<Student> { c.Students.First(s => s.FullName.Equals(studentName, StringComparison.OrdinalIgnoreCase)) }
            })
            .OrderBy(c => c.Name) // Order the courses by their names
            .ToList();
    }

    public List<string> GetCourseNames()
    {
        // Returns a list of all course names
        return courses
            .Select(c => c.Name)
            .OrderBy(name => name) // Order the course names
            .ToList();
    }
}
