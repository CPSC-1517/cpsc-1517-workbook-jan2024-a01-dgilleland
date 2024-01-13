/*
 * File:    Comments.cs
 * Author:  Dan Gilleland
 * Date:    2010
 * Purpose: To illustrate multi-line, single-line, and XML comments.
 *          This is a multi-line comment.
 */
namespace Topic.A.Examples
{
    namespace Temp
    {
        public class Nothingness
        {
            
        }
    }
    /// <summary>
    /// Comments illustrates multi-line, single-line, and XML comments.
    /// </summary>
    /// <remarks>
    /// This class is a stand-alone class used to illustrate comments.
    /// This particular XML comment is "attached" to the class as
    /// a whole, while other XML comments are for fields or methods
    /// in the class (a few methods and fields have been included for
    /// illustration purposes).
    /// [Author: Dan Gilleland]
    /// </remarks>
    public class Comments
    {
        /// <summary>
        /// This is a method of <see cref="Comments"/>
        /// </summary>
        /// <returns>This method returns a string.</returns>
        public static string SimpleMethod()
        {
            return "Hello World!"; // "Hello World!" is a literal string value
        } // end of SimpleMethod()

        /// <summary>
        /// This is a one-sentence description of the method.
        /// </summary>
        /// <param name="name">This is where I describe the purpose of this parameter</param>
        /// <returns>Here I describe what information is returned from this method.</returns>
        /// <remarks>
        /// This method has a single parameter.
        /// </remarks>
        public static int MethodWithParameter(string name)
        {
            return name.Length; // This is a single-line comment (must be end of physical line)
        } // end of MethodWithParameter(string)
    } // end of Comments class
}
