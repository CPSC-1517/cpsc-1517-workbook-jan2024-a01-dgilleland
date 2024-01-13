using static System.Console;
using System;

namespace Topic.B
{
    public class About
    {
        public static void Main(string[] args)
        {
            Clear();
            WriteLine("About the samples/practice for Topic B:");
            WriteLine();
            WriteBulletLine("DemoPerson.cs", "A demo that illustrates the idea of non-static fields (member variables) of a class.");
            WriteBulletLine("DemoAccountDriver.cs", "Another demo to illustrate the use of non-static fields in a class. When you get to the Practice modifications for the `Account` class, this driver should be updated to make use of those changes.");
            WriteBulletLine("DemoSimpleStudentDriver.cs", "Yet-another-demo of non-static fields in a class. Here, the `Student` class illustrates various data types for its fields.");
            WriteBulletLine("DemoStudentDriver.cs", "In this demo, take note of how the driver uses a method with the `Student` data type as a parameter.");
            WriteBulletLine("DemoCompanyAndEmployee.cs", "Here is a driver that uses two classes (`Company` and `Employee`). In addition, the driver shows the use of the `DateTime.Parse()` method as well as calling the `.ToString()` method of a `DateTime` object to format the output.");


            WriteBulletLine("DemoCanadianAddress.cs", "This is a practice problem where you create the class yourself and implement the driver's `Main()` method.");
            WriteBulletLine("DemoCourse.cs", "A practice problem where you create a `Course` class. Note how the driver code is using an instance of the `DemoCourse` class rather than just static methods.");
            WriteBulletLine("DemoExamAndLab.cs", "More practice in coding simple classes with fields. Then, it's time to move on to Topic C!");
        }

        static void WriteBulletLine(string sampleName, string summary)
        {
            WriteLine($"- {sampleName}");
            WriteLine($"\t{summary}");
        }
    }
}