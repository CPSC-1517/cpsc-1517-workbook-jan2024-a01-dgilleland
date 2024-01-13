using System;
using static System.Console;

namespace Topic.B
{
    public class DemoCourse
    {
        public static void Main(string[] args)
        {
            DemoCourse app = new();
            WriteLine("Uncomment the lines in this driver after you have coded the `Course` class.");
            // app.Run();
        }

        // private void Run()
        // {
        //     Course dang_1508 = BuildCourse("DANG-1508", "Practical Database Design and Development", 5, 5, 90);

        //     Display(dang_1508);
        // }

        // private void Display(Course course)
        // {
        //     WriteLine($"{course.CourseNumber} - {course.CourseName} ({course.ClassHours} hrs)");
        // }

        // private Course BuildCourse(string number, string name, int exams, int labs, int hours)
        // {
            
        //     return new Course
        //     {
        //         CourseName = name,
        //         CourseNumber = number,
        //         ExamCount = exams,
        //         LabCount = labs,
        //         ClassHours = hours
        //     };
        // }
    }
}