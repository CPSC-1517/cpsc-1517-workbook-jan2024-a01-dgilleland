using static System.Console;

namespace Topic.C
{
    public class DemoPerson
    {
        public static void Main(string[] args)
        {
            Person somebody = new Person();
            WriteLine("Immediately after constructing a `Person` object, here are it's property values:");
            WriteLine($"\t Age       : {somebody.Age}");
            WriteLine($"\t FirstName : {somebody.FirstName}");
            WriteLine($"\t LastName  : {somebody.LastName}");
            // Why are the FirstName and LastName values not displaying anything?
            // What is the initial value of FirstName and LastName? Is it an empty string "" or `null`?
            WriteLine("Write your own code to play with the modified `Person` class.");
        }
    }
}