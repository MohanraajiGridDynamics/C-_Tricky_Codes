
public class Data
{
    public int CourseID { get; set; }
    public string CourseName { get; set; }
    public object CoursesAvailable { get; set; } // Using object since it's null in your example
    public object Selected_Courses { get; set; } // Also null in your example
}