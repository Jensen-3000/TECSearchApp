namespace TECSearchApp.Logic.Data.Interfaces
{
    public interface ICourseDataLoader
    {
        List<Course> LoadCourses(string[][] data);
    }
}