# Controlled Exit from C# Applications

> The following is a good summary of how to give a controlled exit from a C# application, including how to return an *"Exit Code"*, which may be useful for console-based applications.

![AI](./images/Copilot-AI.png)

To exit a C# console application, you have a few options:

1. **Return from the `Main` Method**:
   The most common way to exit a console application is by returning from the `Main` method. When the `Main` method completes execution, the application will exit. Here's an example:

    ```csharp
    static void Main(string[] args)
    {
        // Your application logic here
        Console.WriteLine("Application is running...");

        // Return from Main to exit the application
        return;
    }
    ```

2. **Use `Environment.Exit`**:
   If you need to forcefully terminate the application from any part of your code, you can use `Environment.Exit(code)`. The `code` parameter represents the exit code (usually 0 for successful termination). Keep in mind that this method is not portable across different environments.

    ```csharp
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Your application logic here
            Console.WriteLine("Application is running...");

            // Forcefully exit the application
            Environment.Exit(0);
        }
    }
    ```

3. **Throw an Exception (for unexpected errors)**:
   If an unexpected error occurs, you can throw an exception without handling it. This will cause the application to terminate.

Choose the method that best suits your application's requirements. Remember that returning from the `Main` method is the most straightforward and recommended approach. 🚀

Source: Conversation with Bing, 2024-03-15

(1) What is the command to exit a console application in C#?. https://stackoverflow.com/questions/10286056/what-is-the-command-to-exit-a-console-application-in-c.

(2) c# exit console - W3schools. https://www.w3schools.blog/c-exit-console.

(3) c# - How do I specify the exit code of a console application in .NET .... https://stackoverflow.com/questions/155610/how-do-i-specify-the-exit-code-of-a-console-application-in-net.

(4) Exit Methods In C# Application - C# Corner. https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/.

(5) c# - Command to close an application of console? - Stack Overflow. https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console.
