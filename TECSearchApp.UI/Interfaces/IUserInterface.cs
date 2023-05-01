﻿namespace TECSearchApp.UI.Interfaces;

public interface IUserInterface
{
    int GetSearchType();
    string GetSearchTerm();
    void DisplayCourses(IEnumerable<Semester> courses, bool hasResults);
    void DisplayInvalidInputMessage();
}