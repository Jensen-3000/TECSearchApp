namespace TECSearchApp.Logic.Models;

public class Course
{
    public string Name { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; }
}
