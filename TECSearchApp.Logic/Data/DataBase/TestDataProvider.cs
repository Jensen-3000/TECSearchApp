namespace TECSearchApp.Logic.Data.DataBase;

public class TestDataProvider : IDataProvider
{

    private readonly string[][] CourseData = new string[][]
    {
    new string[] { "Math", "John Smith", "Alice Adams", "Bob Brown", "Johnny Depp" },
    new string[] { "English", "Jane Doe", "Bob Brown", "Charlie Chen" },
    new string[] { "History", "Bob Johnson", "Diana Davis", "Edward Evans" },
    new string[] { "Science", "Sarah Lee", "Edward Evans", "Frank Foster" },
    new string[] { "Science", "John Smith", "Edward Evans", "Frank Foster" }
    };

    public string[][] GetCourseData()
    {
        return CourseData;
    }
}
