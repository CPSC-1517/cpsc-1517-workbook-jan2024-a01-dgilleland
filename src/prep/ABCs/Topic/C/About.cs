using static System.Console;
using System;

namespace Topic.C
{
    public class About
    {
        public static void Main(string[] args)
        {
            Clear();
            WriteLine("About the samples/practice for Topic C:");
            WriteLine();
            WriteBulletLine("DemoPerson.cs", "This is used for both demos and practice work. Look at the code for the `Person` data type, and complete the driver to make use of this class.");
            WriteBulletLine("DemoAccount.cs", "This is used for both demos and practice work. Discover the `readonly` modifier for fields.");
            WriteBulletLine("DemoStudent.cs", "Discover encapsulation and constructors, as well as overloading the `.ToString()` method.");
            WriteBulletLine("DemoCompanyAndEmployee.cs", "Use Auto-Implemented properties and see why C# started bringing happiness to developers!");
            WriteBulletLine("DemoSchoolDriver.cs", "Wait! What? Where is that driver? Oh, yeah, you (the developer) need to make this driver to play around with your `Course`, `ExamResult`, and `LabResult` classes...");
        }

        static void WriteBulletLine(string sampleName, string summary)
        {
            WriteLine($"- {sampleName}");
            WriteLine($"\t{summary}");
        }
    }
}