namespace TECSearchApp.Logic.Model;

public abstract class Semester
{
    public string CourseName { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; }

}
