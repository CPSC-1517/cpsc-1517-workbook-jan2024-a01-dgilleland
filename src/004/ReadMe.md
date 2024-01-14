# Simple CLI

In the release of .NET 9 (Nov, 2020), Microsoft introduced [**Top-Level Program**](./AboutTLPs.md) files (*TLP*s) to C#. Here, we'll explore them in more detail. Along the way, we'll also get a better understanding of handling command-line arguments and what it means for a console application to return an exit code.

We're also going to introduce the practice of *Test-Driven Development*, or TDD. This document covers the creation of our TLP, and the [next one](./AboutTDD.md) will cover TDD.

----

## Setup

> ***Note:** In the previous demo, we explored how to create .NET projects and solutions using the `dotnet` command-line tool. In that demo, we laid the ground-work for this demo by learning how to create a console application using the [Top-Level Program template](https://aka.ms/new-console-template). You can either delete that code in this folder or move it somewhere else, as we'll be creating a new console application in this demo.*

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

According to [Bing](#wind-chill-formula-from-bing-chat) the formula for wind chill is as follows:

> $$T_{wc} = 13.12 + 0.6215 \times T_a - 11.37 \times V^{0.16} + 0.3965 \times T_a \times V^{0.16}$$
> 
> Where:
> 
> - $T_{wc}$ is the wind chill in degrees celsius
> - $T_a$ is the air temperature in degrees celsius
> - $V$ is the wind speed in kilometers per hour
> 
> For example, if the air temperature is -10°C and the wind speed is 20 km/h, the wind chill is:
>
> $$T_{wc} = 13.12 + 0.6215 \times (-10) - 11.37 \times 20^{0.16} + 0.3965 \times (-10) \times 20^{0.16}$$
>
> $$T_{wc} = -18.76 \text{°C}$$

We could, of course, just create some function to perform our wind child calculations. However, since we have the added complexity of allowing the user to switch to different units for temperature and speed, we would be better served by creating a class to perform all of the work.

### The `WindChill` Class

Parsing the arguments for our wind chill calculations is a little more involved. We could do it inside our TLP, but since the arguments are highly specific to the wind chill calculations, let's just hand-over the arguments to the `WindChill` class through a constructor to let it do the parsing and the construction of the object.

----

## References:

### Wind Chill Formula (from Bing Chat):

The wind chill is a measure of how cold it really feels outside based on the air temperature and wind speed¹. The current formula for the wind chill in celsius and km/h is:

$$T_{wc} = 13.12 + 0.6215 \times T_a - 11.37 \times V^{0.16} + 0.3965 \times T_a \times V^{0.16}$$

Where:

- $T_{wc}$ is the wind chill in degrees celsius
- $T_a$ is the air temperature in degrees celsius
- $V$ is the wind speed in kilometers per hour

For example, if the air temperature is -10°C and the wind speed is 20 km/h, the wind chill is:

$$T_{wc} = 13.12 + 0.6215 \times (-10) - 11.37 \times 20^{0.16} + 0.3965 \times (-10) \times 20^{0.16}$$

$$T_{wc} = -18.76 \text{°C}$$

You can also use the [wind chill calculator](^1^) to estimate the wind chill based on the air temperature and wind speed.

Source: Conversation with Bing, 2024-01-13
(1) Wind Chill Calculator | Good Calculators. https://goodcalculators.com/wind-chill-calculator/.
(2) Wind Chill Calculator | Good Calculators. https://goodcalculators.com/wind-chill-calculator/.
(3) Wind Chill and Humidex Calculators - Environment Canada. https://weather.gc.ca/windchill/wind_chill_e.html.
(4) Wind Chill Calculator. https://www.omnicalculator.com/other/wind-chill.
(5) Wind Chill Calculator (Metric) - CalcuNation. https://www.calcunation.com/calculator/wind-chill-celsius.php.
(6) Wind Chill - Free Math Help. https://www.freemathhelp.com/wind-chill/.

