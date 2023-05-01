namespace TECSearchApp.Logic.Data;

public class CourseDataLoader : ICourseDataLoader
{
    public List<Course> LoadCourses(string[][] data)
    {
        List<Course> courses = new List<Course>();
        foreach (var courseData in data)
        {
            var course = new Course
            {
                Name = courseData[0],
                Teacher = new Teacher { FullName = courseData[1] },
                Students = new List<Student>()
            };

            for (int i = 2; i < courseData.Length; i++)
            {
                course.Students.Add(new Student { FullName = courseData[i] });
            }

            // Order the students by their names
            course.Students = course.Students.OrderBy(s => s.FullName).ToList();

            courses.Add(course);
        }
        // Order the courses by their names
        courses = courses.OrderBy(c => c.Name).ToList();
        return courses;
    }
}

