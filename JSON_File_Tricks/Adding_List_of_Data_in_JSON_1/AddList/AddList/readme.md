The error you're encountering is because you're appending individual JSON objects to a file, which results in an invalid JSON format. According to the JSON specification, a JSON document can only have one top-level value, which in this case is violated by appending multiple JSON objects (separated by newlines) into the same file.

To fix this, you can modify your approach in one of two ways:

1. Wrap all your course data into a single JSON array.
   Instead of appending individual objects to the file, you should write the course data as a single JSON array. This will make the file conform to the JSON standard. Here's how you can do it:

Solution Steps:
First, you need to collect all CourseData objects into a list.

Then, serialize the entire list to a JSON array.

Write the JSON array to the file.

Updated Code:
csharp



List<CourseData> coursesList = new List<CourseData>();

foreach (var course in Selected_Courses)
{
var _courseID = course.Key;
var _courseName = course.Value;

    CourseData courseData = new CourseData
    {
        CourseID = _courseID,
        CourseName = _courseName,
        CoursesAvailable = null,  // or fill in with actual data if needed
        Selected_Courses = null   // or fill in with actual data if needed
    };

    coursesList.Add(courseData);
}

string jsonString = JsonSerializer.Serialize(coursesList);

// This will overwrite the file with the new JSON array
File.WriteAllText(jsonFilePath, jsonString);
Explanation:
We create a List<CourseData> to store all the courses.

After collecting all courses, we serialize the list into a JSON array ([ ... ]).

Finally, we write the array to the file using File.WriteAllText() (this overwrites the existing content in the file).

This will result in a valid JSON file like this:

json

[
{
"CoursesAvailable": null,
"CourseID": 2,
"CourseName": "Web Development with HTML, CSS, and JavaScript",
"Selected_Courses": null
},
{
"CoursesAvailable": null,
"CourseID": 1,
"CourseName": "Introduction to Python Programming",
"Selected_Courses": null
},
{
"CoursesAvailable": null,
"CourseID": 2,
"CourseName": "Web Development with HTML, CSS, and JavaScript",
"Selected_Courses": null
},
{
"CoursesAvailable": null,
"CourseID": 3,
"CourseName": "Machine Learning Fundamentals",
"Selected_Courses": null
}
]
2. If you need to append without overwriting:
   If you still want to append the new courses to the JSON file but ensure it's valid JSON, you'll need to make sure that the file is a valid JSON array, and then append to it correctly. You'd read the file, deserialize the existing JSON array, append the new data, and then rewrite the whole array back to the file.

csharp
Copy
List<CourseData> coursesList = new List<CourseData>();

// Read existing data from the JSON file (if any)
if (File.Exists(jsonFilePath))
{
string existingJson = File.ReadAllText(jsonFilePath);
if (!string.IsNullOrEmpty(existingJson))
{
coursesList = JsonSerializer.Deserialize<List<CourseData>>(existingJson);
}
}

foreach (var course in Selected_Courses)
{
var _courseID = course.Key;
var _courseName = course.Value;

    CourseData courseData = new CourseData
    {
        CourseID = _courseID,
        CourseName = _courseName,
        CoursesAvailable = null,  // or fill in with actual data if needed
        Selected_Courses = null   // or fill in with actual data if needed
    };

    coursesList.Add(courseData);
}

string jsonString = JsonSerializer.Serialize(coursesList);

// Overwrite the file with the updated JSON array
File.WriteAllText(jsonFilePath, jsonString);
This solution allows you to append new data to an existing JSON array without breaking the JSON structure.