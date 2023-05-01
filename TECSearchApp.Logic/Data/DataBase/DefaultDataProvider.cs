namespace TECSearchApp.Logic.Data.DataBase;

public class DefaultDataProvider : IDataProvider
{
    private readonly string[][] CourseData = new string[][]
    {
    new string[] { "Studieteknik", "Niels Olesen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg" },
    new string[] { "Grundlæggende programmering", "Niels Olesen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"},
    new string[] { "Databaseprogrammering", "Niels Olesen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"},
    new string[] { "Objektorienteret Programmering", "Flemming Sørensen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"},
    new string[] { "Computerteknologi", "Niels Olesen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"},
    new string[] { "Clientsideprogrammering", "Peter Suni Lindenskov", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"},
    new string[] { "Netværk I", "Henrik Vincents Poulsen", "Tobias Casanas Besser", "Alexander Mathias Thamdru", "Allan Gawron", "Andreas Carl Balle", "Darab Haqnazar", "Felix Enok Berger", "Jamie J. d. I. S. E. -D", "Jeppe Carlseng Pedersen", "Joseph Holland-Hale", "Kamil Marcin Kulpa", "Loke Emil Bendtsen", "Mark Hyrsting Larsen", "Niklas Kim Jensen", "Rasmus Peter Hjorth", "Sammy Damiri", "Thomas Mose Holmberg"}
    };

    public string[][] GetCourseData()
    {
        return CourseData;
    }
}
