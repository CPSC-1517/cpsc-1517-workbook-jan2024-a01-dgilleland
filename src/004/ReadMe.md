# Simple CLI

In the release of .NET 9 (Nov, 2020), Microsoft introduced [**Top-Level Program**](./AboutTLPs.md) files (*TLP*s) to C#. Here, we'll explore them in more detail. Along the way, we'll also get a better understanding of handling command-line arguments and what it means for a console application to return an exit code.

We're also going to introduce the practice of *Test-Driven Development*, or TDD. This document covers the creation of our TLP, and the [next one](./AboutTDD.md) will cover TDD.

----

## Setup

> ***Note:** In the previous demo, we explored how to create .NET projects and solutions using the `dotnet` command-line tool. In that demo, we laid the ground-work for this demo by learning how to create a console application using the [Top-Level Program template](https://aka.ms/new-console-template). You can either delete that code from this folder or move it somewhere else, as we'll be creating a new console application in this demo.*

Let's build a CLI application that makes use of command-line arguments. For this demo, we'll build a simple application that calculates the wind chill based on the air temperature and wind speed.

- [ ] Create a console app called **`WindChill`** under `~/src/004/` along with a solution of the same name. Ensure you create the program without `--use-program-main`. *(Technically speaking, a single project does not need a solution file, but we'll create one anyway.)*
- [ ] Add the folder to your workspace.

```
📂 ~ (Workbook Root)
 | 📂 src
    | 📂 004
       | 📂 WindChill
       |  | 🗒️ Program.cs
       |  | ⚙️ WindChill.csproj
       | ⚙️ WindChill.sln
```

## Application Design

We'll expect the user to provide information to our program as command-line arguments. We'll assume the speed is in kilometers per hour and the temperature is in degrees celsius unless the user specifies otherwise through some optional "flags" (`-f` for Farenheit and/or `-m` for miles per hour).

Our main program will be a top-level program, and we'll have a `WindChill` class that will do the actual calculations. We'll also have a `Help` method that will display the usage information for our CLI if any of the arguments are wrong or if the user specifies the `-h` or `--help` flag.

Let's start with a function to display the help information. This will be a local function in our TLP.

```cs
void ShowHelp()
{
    WriteLine("This is a CLI to calculate wind chill.");
    WriteLine("Usage: dotnet run -- <temperature> <wind speed> <options>");
    WriteLine();
    WriteLine("Arguments:");
    WriteLine("  <temperature>\tAir Temperature (in Celsius by default)");
    WriteLine("  <wind speed>\tWind Speed (in km/h by default)");
    WriteLine();
    WriteLine("Options:");
    WriteLine("  -f\t\tTemperature in Fahrenheit");
    WriteLine("  -m\t\tWind speed in m/h");
    WriteLine("  --help\tShow this help message");
}
```

Notice that we're using the `WriteLine` method without specifying the `Console` class. This is because our TLP will have a `using static System.Console` statement at the top of the file.

```cs
// Using statements must be at the top of the file
using static System.Console; // so we can use Console.WriteLine() as WriteLine()
```

## Handling the Inputs

We'll begin our TLP by examining the command-line arguments in the `args` parameter. Generally, we're expecting the first two to be numbers for the temperature and wind speed (in that order). We'll also allow a possible third argument to specify the use of Fahrenheit and/or miles per hour.

If those arguments are not present, we'll display the help information and exit with a code of `1`. We'll also display the help information if the user specifies the `-h` or `--help` flag, but our exit code will be `0` in that case.

```cs
// Check the arguments
int exitCode = 0;
if (args.Length < 2)
{
    if(args.Length == 0 || (args[0] != "--help" && args[0] != "-h"))
        exitCode = ProcessError("Invalid arguments.");

    ShowHelp();
}
else if (args.Length < 4)
{
    // TODO: Parse the arguments and calculate the wind chill
    ForegroundColor = ConsoleColor.Yellow;
    WriteLine("Not Yet Implemented");
    ResetColor();
}
else
{
    exitCode = ProcessError("Invalid arguments.");
    ShowHelp();
}
return exitCode;
```

I imagine we will be able to clean up this code a bit once we have the `WindChill` class in place. For now, let's just focus on the `ProcessError` method. That method will display an error message and return an exit code of `1`.

```cs
int ProcessError(string message)
{
    ForegroundColor = ConsoleColor.Red;
    WriteLine($"Error: {message}");
    WriteLine("Review the --help for usage information.");
    ResetColor();
    return 1;
}
```

## Run the Program

At this point, we should be able to run our program (even if it doesn't do the calculations yet). Navigate in the terminal to the `WindChill` folder and launch the program by typing `dotnet run`.

Notice how we got the error message. Let's try running again by passing in some arguments to our program.

```ps
dotnet run -- -10 20
```

The double-dash (`--`) in the command indicates that the rest of the line will be arguments that we pass to our program. These arguments are space and comma delimited.

## Calculating the Wind Chill


We could, of course, just create some function to perform our wind chill calculations. It turns out that the [calculations](./WindChill.md) are a little complex. However, since we also want to allow the user to switch to different units for temperature and speed, we would be better served by creating a class &ndash; `WindChill` &ndash; to perform all of the work.

At this point, we're going to introduce the concept of *unit testing* to help us manage the complexity we're facing. It will also give us better confidence that our code will work as intended. It's time to [learn about **TDD**](./AboutTDD.md)!
