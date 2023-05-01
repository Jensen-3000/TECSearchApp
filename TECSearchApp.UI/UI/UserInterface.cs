namespace TECSearchApp.UI.UI;

public class UserInterface
{
    private readonly ICourseManager courseManager;

    public UserInterface(ICourseManager courseManager)
    {
        this.courseManager = courseManager;
    }

    public void RunMenuLoop()
    {
        while (true)
        {
            PrintMenuOptions();
            int? input = GetValidInput();

            if (input == null)
            {
                Console.Clear();
                Console.WriteLine("Ugyldigt input. Prøv igen.\n");
                continue;
            }

            if (input == 0)
            {
                return;
            }

            RunSearchOption((SearchType)input);
            Console.WriteLine();
        }
    }

    private void PrintMenuOptions()
    {
        Console.WriteLine("Vælg en søgning:");
        foreach (SearchType option in Enum.GetValues(typeof(SearchType)))
        {
            Console.WriteLine($"{(int)option}. {option}");
        }
        Console.WriteLine("0. Exit");
    }

    private int? GetValidInput()
    {
        // Reads the key as soon as it's pressed without needing to press Enter.
        // Note: This will not work correctly with multiple digit numbers.
        var key = Console.ReadKey(true); // true to hide the pressed key
        if (!int.TryParse(key.KeyChar.ToString(), out int input) || input < 0 || input > Enum.GetNames(typeof(SearchType)).Length)
        {
            return null;
        }

        return input;
    }

    private void RunSearchOption(SearchType option)
    {
        if (option == SearchType.Fag)
        {
            DisplayAllCourses();
        }

        Console.Write($"Indtast søgeord for {option.ToString().ToLower()}: ");
        var name = Console.ReadLine().Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.Clear();
            Console.WriteLine("Ugyldigt søgeord. Prøv igen.\n");
            return;
        }

        List<Course> courses;
        switch (option)
        {
            case SearchType.Fag:
                courses = courseManager.SearchByCourseName(name);
                break;
            case SearchType.Lærer:
                courses = courseManager.SearchByTeacherName(name);
                break;
            case SearchType.Elev:
                courses = courseManager.SearchByStudentName(name);
                break;
            default:
                return;
        }

        Console.Clear(); // Clear the console screen

        if (courses.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("\nIngen resultater fundet.");
            return;
        }

        int currentIndex = 0;
        int totalCourses = courses.Count;
        foreach (var course in courses)
        {
            currentIndex++;
            Console.WriteLine($"({currentIndex} ud af {totalCourses})");
            DisplayCourseInfo(course, option);
        }
    }

    private void DisplayCourseInfo(Course course, SearchType option)
    {
        if (option != SearchType.Fag)
        {
            Console.WriteLine($"{SearchType.Fag}: {course.Name}");
        }
        if (option != SearchType.Lærer)
        {
            Console.WriteLine($"\n{SearchType.Lærer}: {course.Teacher.FullName}");
        }
        Console.WriteLine($"\n{SearchType.Elev}er:");
        for (int i = 0; i < course.Students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {course.Students[i].FullName}");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40)); // Adding separator for clarity
        Console.WriteLine();
    }

    private void DisplayAllCourses()
    {
        var courseNames = courseManager.GetCourseNames();
        Console.WriteLine($"\nListe af {SearchType.Fag} du kan søge på:\n");
        foreach (var courseName in courseNames)
        {
            Console.WriteLine($"- {courseName}");
        }
        Console.WriteLine("\n");
    }
}
