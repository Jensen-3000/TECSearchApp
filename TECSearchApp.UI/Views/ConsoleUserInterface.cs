namespace TECSearchApp.UI.Views;

/// <summary>
/// Provides a console-based user interface for the TECSearchApp.
/// </summary>
public class ConsoleUserInterface : IUserInterface
{
    /// <summary>
    /// Prompts the user to select a search type and returns their selection.
    /// </summary>
    /// <returns>The selected search type, or -1 if the input was invalid.</returns>
    public int GetSearchType()
    {
        Console.WriteLine($"Vælg en søgning:");
        Console.WriteLine($"1. {SearchType.Lærer}");
        Console.WriteLine($"2. {SearchType.Elev}");
        Console.WriteLine($"3. {SearchType.Fag}");

        string input = Console.ReadKey(true).KeyChar.ToString();
        if (Enum.TryParse<SearchType>(input, out SearchType searchType))
        {
            return (int)searchType;
        }
        else
        {
            return -1; // invalid input
        }
    }

    /// <summary>
    /// Prompts the user to enter a search term and returns their input.
    /// </summary>
    /// <returns>The user's search term.</returns>
    public string GetSearchTerm()
    {
        Console.WriteLine("\nIndtast søgeord:");
        return Console.ReadLine().Trim();
    }

    /// <summary>
    /// Displays a list of courses to the console, 
    /// adjusting the display based on the type of search performed.
    /// </summary>
    /// <param name="courses">The list of courses to display.</param>
    /// <param name="hasResults">Whether the search returned any results.</param>
    /// <param name="searchType">The type of search that was performed. This determines what information is displayed for each course.</param>
    public void DisplayCourses(IEnumerable<Semester> courses, bool hasResults, SearchType searchType)
    {
        if (hasResults)
        {
            Console.Clear();
            int courseNumber = 1;
            int totalCourses = courses.Count();
            foreach (Semester course in courses)
            {
                Console.WriteLine($"{courseNumber} ud af {totalCourses}");

                if (searchType != SearchType.Fag)
                {
                    Console.WriteLine($"{SearchType.Fag}: {course.CourseName}");
                }

                if (searchType != SearchType.Lærer)
                {
                    Console.WriteLine($"{SearchType.Lærer}: {course.Teacher.FullName}");
                }

                if (searchType != SearchType.Elev)
                {
                    Console.WriteLine($"{SearchType.Elev}er:");
                    int studentNumber = 1;
                    foreach (Student studentName in course.Students)
                    {
                        Console.WriteLine($"  {studentNumber}. {studentName.FullName}");
                        studentNumber++;
                    }
                }

                Console.WriteLine();
                Console.WriteLine(new string('-', 40)); // Adding separator for clarity
                Console.WriteLine();
                courseNumber++;
            }
        }
        else
        {
            DisplayNoResultsFoundInSearch();
        }
    }

    private void DisplayNoResultsFoundInSearch()
    {
        Console.Clear();
        Console.WriteLine("Ingen resultater fundet.\n");
    }

    public void DisplayInvalidInputMessage()
    {
        Console.Clear();
        Console.WriteLine("Ugyldigt input. Prøv igen.\n");
    }

    public void DisplayAvailableCourses(IEnumerable<Semester> semesters)
    {
        var distinctCourses = semesters.Select(s => s.CourseName).Distinct();
        
        Console.WriteLine($"\nListe af {SearchType.Fag} du kan søge på:\n");
        foreach (var course in distinctCourses)
        {
            Console.WriteLine($"{course}");
        }
        Console.WriteLine();
    }
}
