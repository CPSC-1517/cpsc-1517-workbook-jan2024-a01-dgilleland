# Intro to Test-Driven Development

> ***Note:** The notes here are still in rough format. Check back later for more details.*

**Test-Driven Development** (*TDD*) is one of the best practices for building software applications. As we work to complete our application, we will make use of TDD practices to guide our application's internal functionality. For this, we will need to have another project as part of our solution: An **XUnit** project.

## Setup

Using the terminal, run the following from inside the `~/src/004` folder.

```ps
dotnet new xunit -o WindChill.Specs -n WindChill.Specs
```

Then, let's add that to our solution.

```ps
dotnet sln add WindChill.Specs/WindChill.Specs.csproj
```

Now, change directory to the testing folder and add in a reference to our WindChill application and a package for a library called `FluentAssertions`.

```ps
cd WindChill.Specs
dotnet add reference ../WindChill/WindChill.csproj
dotnet add package FluentAssertions
```

Open the `GlobalUsings.cs` and modify the code so that it reads as follows.

```cs
global using Xunit;
global using FluentAssertions;
```

## Coding With Confidence

Developers face several challenges when it comes to creating software. One of the biggest challenges is that of *uncertainty*. How can we be sure if our code is going to work the way we expect it to? Yes, we can write code that compiles, but that doesn't mean it's going to work. And we can write code that works, but that doesn't mean it's going to work in all situations. But, even if we do manage to write code that works in all situations, that doesn't mean it's going to work when we need to *change* it.

### Automated Tests

One of the early ways developers tried to address this uncertainty was through the use of **Automated Tests**. Creating automated tests is a practice where we write code that tests our code. That is, we create code (*tests*) that embody the expectations about how our production code should work. We then run those tests to see if our code works the way we expect it to. If it does, then we can be more confident that our code is working. If it doesn't, then we know we need to fix our code.

The big benefit of automated tests is that it's much *faster* to run an automated test suite to check for errors than it is to manually test our code. Not only is it much faster, it's a whole lot more *consistent* than relying upon manual tests. Because we can run all of our tests at once, we can be more *thourough* in our testing. All of this helps us to create new code with more confidence.

But automated tests don't just help with creating new code. They also help with *maintaining* our code. As we make changes to one part of our code, we can run our tests to make sure that our changes don't break anything else. This is especially important when we're making changes to code that already works. We want to make sure that our changes don't break anything. This is called **Regression Testing**. Regression Testing is the practice of running all of our tests to make sure that our code still works after we've made changes to it.

### Types of Tests

There are different kinds of automated tests. One of the oldest and best known are **Unit Tests**. Unit tests focus on a small unit of functionality for our code base. For example, we might have a unit test that checks to see if a method returns the correct value. Or we might have a unit test that checks to see if a method throws an exception when it's supposed to.

Unit tests are great for testing small units of functionality, but they're not so great for testing larger units of functionality. For that, we need a different kind of test: **Integration Tests**. Integration tests are used to test larger units of functionality, particularly when they cross some sort of *processing boundary*.

Integration tests are great for testing larger units of functionality, but they're not so great for testing the entire breadth of an application. For that, we need **End-to-End Tests**.

That's not the end of the list. There are also **Acceptance Tests**, **Smoke Tests**, **Performance Tests**, and more. Each of these tests are used to test different aspects of our application.

Since this is an introduction to TDD, we're going to focus on Unit Tests. But, before we do that, we need to talk about the practice of TDD.

### What is TDD?

TDD encourages a software development process that relies on the repetition of a very short development cycle &ndash; Red-Green-Refactor &ndash; as a means to *drive* the software design/development process. In other words, we write a test that fails, then we write the code to make the test pass, and then we refactor the code to make it better. Then we repeat the process.

If you're new to TDD, you might be thinking that it's the same thing as Unit Testing. It's not. Unit Testing is a practice that is used in TDD, but TDD is more than just Unit Testing. With TDD, we are focused on writing our tests *first* and then writing the code to make the tests pass. The big benefit in this mindset is that by writing the tests first we are effectively *designing* our code before we write it. In TDD, our automated tests (such as unit tests) will embody the **specification** of our application. This helps us to write better code.

There's much more to learn about TDD, and it will be a little while before you start writing your own tests. But, for now, let's take a look at how we can use TDD to help us build our Wind Chill application.

----

## Testing for WindChill

In the [previous document](./ReadMe.md), we decided to create a class to calculate the wind chill temperature. Central to that is this [formula](./WindChill.md):

$$
13.12 + (0.6215 \times T) - 11.37 \times (V^{0.16}) + 0.3965 \times T (V^{0.16})
$$

Let's create a small bit of test data to help us check that our math is correct. We'll use the info we gathered from our research.

> *Grab your calculator and make sure [my math](./WindChill.md#the-wind-chill-formula) is correct here! If you get something different, ask yourself "Why" and keep those thoughts in the back of your mind as we move forward.*

| Air Temp (°C) | Wind Speed (km/h) | Wind Chill |
| :--: | :--: | :--: |
| -10 | 20 | -17.855 |

### Preliminary Thoughts

Our `WindChill` class is meant to embody everything related to calculating the wind chill for a specific set of conditions. Before we create the class, let's think through what we want it to do. Our `WindChill` class should:

- [ ] Be able to calculate the wind chill for a given set of conditions (*Air Temperature* and *Wind Speed*).
- [ ] Be biased toward using the *Celsius* scale for *Air Temperature* and *km/h* for *Wind Speed* (unless otherwise directed).
- [ ] Be able to handle different units of measurement for the *Air Temperature* and *Wind Speed* (i.e.: Farenheit and miles per hour).
- [ ] Retain knowledge of the set of conditions for the calculated wind chill (even *after* the calculation is complete).
- [ ] Represent the entire result in a meaningful way (i.e.: as a simple formatted string).

How will our class get the information needed for the calculations? We could pass in the values as arguments to a method, but that would mean that we would have to pass in the values every time we wanted to calculate the wind chill. That's not very convenient. Instead, let's pass in the values when we create the object. That way, we can just create the object and then ask it for the wind chill.

#### Constructor(s)

To begin with, we'll need a constructor that takes in the *Air Temperature* and *Wind Speed* as arguments; in this situation, we'll presume the Celsius and km/h units. This is the simplest situation, so it will be the first one we'll tackle. We will also need a constructor that allows us to specify units of measurement for both or either the *Air Temperature* and *Wind Speed*.

In accepting temperature and speed as input, we should think about what limits we might want to put on those values. After all, we don't typically talk about "wind chill" when it's a balmy 32°C outside. And we don't typically talk about "wind chill" when the wind is barely blowing. So, let's put some limits on the values we accept.

- [ ] Require temperatures to be below freezing.
- [ ] Require wind speeds to be between 10 and 70km/h

We might also want to think about how our driver is going to be handling our class. We know that the user will be sending in arguments as an array of strings, and given the possible combinations of required and optional information, parsing those arguments can become a bit cumbersome. Yes, we could do those string translations inside our TLP driver, but since the arguments are highly specific to the wind chill calculations, let's just hand over the arguments to the `WindChill` class and let it specify how that should be handled.

### Our Initial Tests

> *Note: We're going to be using the [FluentAssertions](https://fluentassertions.com/) library to help us write our tests. If you're not familiar with this library, you can learn more about it [here](https://fluentassertions.com/introduction).*

Writing automated tests is a bit of a skill. It's not hard, but it does take some practice. Usually, the best practice is to get exposed to reading tests before you start writing your own. Yes, you'll do the "coding", but for now, I'll be providing the tests for you to write. *Your* job will be to write the code that makes the tests pass!




### Our Final Calculation


So far, that looks good. But we should remember that the formula is using exponents (e.g.: $T^{0.16}$) and other fractional values (e.g.: $0.6215$). Unless we employ precise rounding at certain points of our calculations, we'll probably get some failed tests. Therefore, we'll use some *aproximations* in our tests.


----

## Appendix

### `WindChill_Should.cs`

Here's the complete code for the `WindChill_Should` class.

```cs
```

### `WindChill.cs`

Here's the complete code for the `WindChill` class.

```cs
```


----

----

# TEMP

```cs
// Using statements must be at the top of the file
using System;
using static System.Console; // so we can use Console.WriteLine() as WriteLine()

// The body of the Main method is the next item in the file
WriteLine("Hello Wind Chill!");
// TODO: Add code to parse the arguments and calculate the wind chill
// For now, we'll just exit with a code of 0
return 0;

// Members of the class (fields, properties, and methods) are to be placed after the body of the Main method
// Fields
public static const double FreezingPointCelsius = 0.0;
private static double _TemperatureCelcius;
private static double _WindSpeedKmH;

public static double WindChill { get; private set; }
public static char Units { get; private set; } // 'F' or 'C'

// Methods
public static double ConvertToFarhenheit(double temperatureCelcius)
{
    return temperatureCelcius * 9 / 5 + 32;
}
public static double ConvertToCelsius(double temperatureFahrenheit)
{
    return (temperatureFahrenheit - 32) * 5 / 9;
}
public static double ConvertToMilesPerHour(double windSpeedKmH)
{
    return windSpeedKmH / 1.609344;
}
public static void CalculateWindChill()
{
    // Based on fields/properties, this will set the WindChill property
    // Assuming that _TemperatureCelcius and _WindSpeedKmH have been set
    // first, calculating the results in Celsius
    double windChillCelsius = 13.12 + 0.6215 * _TemperatureCelcius - 11.37 * Math.Pow(_WindSpeedKmH, 0.16) + 0.3965 * _TemperatureCelcius * Math.Pow(_WindSpeedKmH, 0.16);
    // Adjust the wind chill based on the units
    if (Units == 'F')
    {
        WindChill = ConvertToFarhenheit(windChillCelsius);
    }
    else
    {
        WindChill = windChillCelsius;
    }
}
    WriteLine($"Temperature: {args[0]}°C");
    WriteLine($"Wind Speed: {args[1]} km/h");


public static void ShowHelp()
{
    WriteLine("This is a CLI to calculate wind chill.");
    WriteLine("Usage: dotnet run -- <temperature> <wind speed> <options>");
    WriteLine();
    WriteLine("Arguments:");
    WriteLine("  <temperature>\tAir Temperature (in Celsius by default)");
    WriteLine("  <wind speed>\tWind Speed (in km/h by default)");
    WriteLine();
    WriteLine("Options:");
    WriteLine("  --help\tShow this help message");
    WriteLine("  -f\t\tTemperature is in Fahrenheit");
    WriteLine("  -m\t\tWind speed is in m/h");
}
```

----
