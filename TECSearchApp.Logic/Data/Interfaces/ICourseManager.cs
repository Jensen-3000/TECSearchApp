namespace TECSearchApp.Logic.Data.Interfaces
{
    public interface ICourseManager
    {
        List<string> GetCourseNames();
        void LoadData(string[][] data);
        List<Course> SearchByCourseName(string courseName);
        List<Course> SearchByStudentName(string studentName);
        List<Course> SearchByTeacherName(string teacherName);
    }
}