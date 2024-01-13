using static System.Console;
using System;

namespace Topic.A
{
    public class About
    {
        public static void Main(string[] args)
        {
            Clear();
            WriteLine("About the samples/practice for Topic A:");
            WriteLine();
            WriteBulletLine("Program.cs", "The classic \"Hello World\" program.");
            WriteBulletLine("Comments.cs", "A demo of the different types of comments supported by C#");
            WriteBulletLine("HelloWorld_Driver.cs", "Driver to demonstrate an OOP-styled \"Hello World\" program using the `Salutation` class.");
            WriteBulletLine("AM_Driver.cs", "A practice problem where you create an answering machine class. This program is designed to accept a single string passed in as the name of the person owning the answering machine.");
        }

        static void WriteBulletLine(string sampleName, string summary)
        {
            WriteLine($"- {sampleName}");
            WriteLine($"\t{summary}");
        }
    }
}