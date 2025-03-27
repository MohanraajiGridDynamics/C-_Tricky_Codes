// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Text.Json;
using AddList;

class Program
{
    static void Main(string[] args)
    {

        string jsonFilePath =
            "/Users/mmohanraaji/Documents/E/C_Sharp_Tips_and_Tricks/JSON_File_Tricks/Adding_List_of_Data_in_JSON/AddList/AddList/Data.json";
        //Let us say you have a list of data, but not fixed , it needs to be stored in the JSON file
        //The Issue you'll face is "JSON standard allows only one top-level value" because everything you insert will be just stacked 
        // Inorder to overcome that issue, we come up with a different approach
        
        Dictionary<int, string> Courses = new Dictionary<int, string>();
        //Let's say this Dictionary contains the data of the courses that needs to be written to the JSON file
        
        Courses.Add(1, "Math");
        Courses.Add(2, "English");
        Courses.Add(3, "Science");
        
        
        List<Data> data = new List<Data>();

        foreach (var coruse in Courses)
        {
            var _courseID = coruse.Key;  // using the _ defines that the var doesnt care about the data type
            var _courseName = coruse.Value;

            Data newData = new Data
            {
                CoruseID = _courseID,
                CoruseName = _courseName
            };
            
            data.Add(newData);
        }

        string jsonString = JsonSerializer.Serialize(data);
        
        File.WriteAllText(jsonFilePath, jsonString);
        
        Console.WriteLine("Done");
    }
}

// By using this method we can add the data to the JSON as Arrays [] , and overcome issues.