// Instructions: Enter comments in each blank to describe the following code
// Declare a Namespace or "group" under which to place my Salutation class as a way of organizing my classes/data types
namespace Topic.A
{

    // Declare a new data type called "Salutation" as a class type
    public class Salutation
    {
        // Declare a static method called "Greeting" that has no parameters and promises to return a string.
        public static string Greeting()
        {
            // Return a hard-coded (or "literal") string value
            return "Hello World!";
        } // end of Greeting()

        // Declare a static method called "Greeting" that has a single parameter (a string) and promises to return a string. This method is an overload of the previous method.
        public static string Greeting(string name)
        {
            // _____________________________________________________________
            return "Hello " + name;
        } // end of Greeting(string)

        // _________________________________________________________________
        public static string Farewell()
        {
            // _____________________________________________________________
            return "So long!";
        } // end of Farewell()
    } // end of Salutation class
}