// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Path to your JSON file
        string filePath = "/Users/mmohanraaji/Documents/E/C_Sharp_Tips_and_Tricks/JSON_File_Tricks/Reading_List_of_Data_from_JSON/ReadList/ReadList/data.json"; // Change this to the correct file path

        // Read the JSON content from the file
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON string to a list of Course objects
        List<Data> courses = JsonSerializer.Deserialize<List<Data>>(jsonContent);

        // Output the data to verify
        foreach (var course in courses)
        {
            Console.WriteLine($"CourseID: {course.CourseID}");
            Console.WriteLine($"CourseName: {course.CourseName}");
            Console.WriteLine($"CoursesAvailable: {course.CoursesAvailable}");
            Console.WriteLine($"Selected_Courses: {course.Selected_Courses}");
            Console.WriteLine();
        }
    }
}