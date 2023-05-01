namespace TECSearchApp.Logic.Interfaces;

public interface ISemesterService
{
    List<Semester> GetCoursesFromData();
    IEnumerable<Semester> SearchTeacher(string teacherName);
    IEnumerable<Semester> SearchStudent(string studentName);
    IEnumerable<Semester> SearchCourse(string courseName);
    IEnumerable<Semester> Search(SearchType searchType, string searchTerm);
}
