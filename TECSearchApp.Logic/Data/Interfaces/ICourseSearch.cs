namespace TECSearchApp.Logic.Data.Interfaces
{
    public interface ICourseSearch
    {
        void SetCourses(List<Course> courses);
        List<string> GetCourseNames();
        List<Course> SearchByCourseName(string courseName);
        List<Course> SearchByStudentName(string studentName);
        List<Course> SearchByTeacherName(string teacherName);
    }
}