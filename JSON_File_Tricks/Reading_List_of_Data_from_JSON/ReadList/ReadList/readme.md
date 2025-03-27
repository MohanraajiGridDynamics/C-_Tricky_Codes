To read and parse the given JSON data in C#, you can use the Newtonsoft.Json (Json.NET) library. Here's a step-by-step guide:

Steps:
Install Newtonsoft.Json NuGet package: You need to install the Newtonsoft.Json package if you haven't already. You can do this using the NuGet package manager in Visual Studio or via the Package Manager Console with the following command:


````
Install-Package Newtonsoft.Json
````

Create the appropriate C# classes: You need to define C# classes that correspond to the structure of your JSON data. Based on the structure of your JSON, we can create classes like this:

````
public class Course
{
public int CourseID { get; set; }
public string CourseName { get; set; }
public object CoursesAvailable { get; set; } // Using object since it's null in your example
public object Selected_Courses { get; set; } // Also null in your example
}
````

Read and Deserialize the JSON: Next, you will read the JSON file, deserialize it into the C# objects, and process the data.

Here's an example of how to do it:

````
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
static void Main(string[] args)
{
// Path to your JSON file
string filePath = "path_to_your_file.json"; // Change this to the correct file path

        // Read the JSON content from the file
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON string to a list of Course objects
        List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(jsonContent);

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

````

Explanation:
The File.ReadAllText method reads the JSON content from the file.

JsonConvert.DeserializeObject<List<Course>>(jsonContent) converts the JSON string into a list of Course objects.

Then, we loop through the list and print each course's properties to the console.

Example Output:
Assuming the JSON file has the data you provided, the output might look like this:

````
CourseID: 2
CourseName: Web Development with HTML, CSS, and JavaScript
CoursesAvailable:
Selected_Courses:

CourseID: 1
CourseName: Introduction to Python Programming
CoursesAvailable:
Selected_Courses:

CourseID: 2
CourseName: Web Development with HTML, CSS, and JavaScript
CoursesAvailable:
Selected_Courses:

CourseID: 3
CourseName: Machine Learning Fundamentals
CoursesAvailable:
Selected_Courses:
This way, you can read and process the JSON data in C#.
````

You said:
Without NewtonSoft

ChatGPT said:
If you want to read and parse the JSON data in C# without using Newtonsoft.Json, you can use the built-in System.Text.Json namespace, which is available in .NET Core and later versions of the .NET Framework.

Here's how you can do it:

Steps:
Define the C# Classes: These classes will represent the structure of your JSON data.

````
public class Course
{
public int CourseID { get; set; }
public string CourseName { get; set; }
public object CoursesAvailable { get; set; } // Using object since it's null in your example
public object Selected_Courses { get; set; } // Also null in your example
}

````
Read and Deserialize the JSON: You can use System.Text.Json.JsonSerializer to deserialize the JSON into your C# objects.

Here's an example:

csharp
Copy
```
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
static void Main(string[] args)
{
// Path to your JSON file
string filePath = "path_to_your_file.json"; // Change this to the correct file path```

        // Read the JSON content from the file
        string jsonContent = File.ReadAllText(filePath);

        // Deserialize the JSON string to a list of Course objects
        List<Course> courses = JsonSerializer.Deserialize<List<Course>>(jsonContent);

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

```

Explanation:

File.ReadAllText(filePath) reads the JSON content from the file.

JsonSerializer.Deserialize<List<Course>>(jsonContent) converts the JSON string into a list of Course objects.

Then, we loop through the list and print each course's properties to the console.

Example Output:
With the given JSON data, the output should look like this:


````
CourseID: 2
CourseName: Web Development with HTML, CSS, and JavaScript
CoursesAvailable:
Selected_Courses:

CourseID: 1
CourseName: Introduction to Python Programming
CoursesAvailable:
Selected_Courses:

CourseID: 2
CourseName: Web Development with HTML, CSS, and JavaScript
CoursesAvailable:
Selected_Courses:

CourseID: 3
CourseName: Machine Learning Fundamentals
CoursesAvailable:
Selected_Courses:

`````

Notes:
System.Text.Json is part of .NET Core 3.0 and later, as well as .NET 5+.

The object type is used for CoursesAvailable and Selected_Courses in this example because they are null in your JSON data. If those fields will always be null, you might also consider using JsonElement? if you want to handle it more specifically.

This method does not require external libraries, as System.Text.Json is built into the .NET framework itself.