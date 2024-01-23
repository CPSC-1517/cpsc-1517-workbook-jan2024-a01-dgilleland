# Completing the WindChill CLI

In this article, we will explore using a **builder pattern** for creating our `WindChill` objects from command-line parameters. When we are done, we should have a fully-functional command-line interface (CLI) for our `WindChill` class.

----

## Revisiting Our Driver

If you recall, our driver code was incomplete. We had a spot in our code to make use of the `WindChill` class, but we hadn't written the code to actually create the `WindChill` object. Let's revisit that code now.

```cs
// Check the arguments
int exitCode = 0;
if (args.Length < 2) // We expect a minimum of two arguments
{
    if(args.Length == 0 || (args[0] != "--help" && args[0] != "-h"))
        exitCode = ProcessError("Invalid arguments.");

    ShowHelp();
}
else if (args.Length < 5) // We allow a maximum of four arguments
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

The first thing that struck me about the code is the way my `if`/`else` statements were organized. The first and last code blocks were all about handling an invalid number of arguments. The middle code block was about handling the valid number of arguments. I decided to reorganize the code so that we can have a single block for handling the invalid arg count and a block to run our actual program.

First, I wanted to make my conditions for the if statements more readable. I decided to create a couple of simple functions to check the argument count and to check if the user was asking for help.

```cs
bool HasCorrectArgCount()
{
    return args.Length >=2 && args.Length <=4;
}

bool HasHelpArg()
{
    return args.Length > 0 && (args[0] == "--help" || args[0] == "-h");
}
```

Then, I re-arranged the main code block to have a cleaner if/else structure.

```cs
int exitCode = 0;
if (HasCorrectArgCount())
{
    // TODO: Parse the arguments and calculate the wind chill
    ForegroundColor = ConsoleColor.Yellow;
    WriteLine("Not Yet Implemented");
    ResetColor();
}
else
{
    if(!HasHelpArg())
        exitCode = ProcessError("Invalid arguments.");
    ShowHelp();
}
return exitCode;
```

I personally find this code a bit easier to read and understand.

Let's just quickly run the code in the terminal to see if we broke anything.

```ps
# Run the program from the root of the WindChill project
dotnet run -- -10 20
```

Try a few other combinations of arguments on your own to make sure we didn't break anything.

Now, how are we going to parse the arguments to make use of our `WindChill` class? There's more than one way to do this, but I'm going to use a **builder pattern**.

## The Builder Pattern

A **builder pattern** is a design pattern that allows us to create an object in a step-by-step fashion. There's nothing really fancy here; we're only relegating the creation of our object to a particular method. The question is, where will I put that method?

I'm going to put it as a `static` method on the `WindChill` class. Some may prefer other places, but since our array of strings (`args`) is related entirely to the `WindChill` class, I think it makes sense to put the parsing code there.

I'm going to first build a little unit test to give me some confidence that I'm doing it right.

### Unit Testing the Builder

We had some test data in a prior document. Here's that same test data, but reformatted a bit. We'll also re-order our attributes so that the temperature and wind speed are first (to keep in line with what we said in our help information).

| Valid Inputs               |
| :------------------------- |
| `["-10", "20"]`            |
| `["32", "10", "-f", "-m"]` |

Create a new test class in the `WindChill.Specs` project, and name the class `WindChillBuilder_Should`.

Next, create a theory that will check all of those valid input combinations. All that we're interested in is that the builder is able to take those inputs and produce a `WindChill` object.

```cs
[Theory]
[InlineData("-10", "20")]
[InlineData("32", "10", "-f", "-m")]
public void Build_WindChill_From_Valid_String_Array(params string[] args)
{
    // Arrange
    WindChill actual;
    Action act = () => actual = WindChill.Build(args);
    // Act
    // Assert
    act.Should().NotThrow();
    actual.Should().NotBeNull();
}
```

### Passing Our Test

Let's write code to pass our first test.

```cs
public static WindChill Build(string[] args)
{
    double airTemp = double.Parse(args[0]);
    double windSpeed = double.Parse(args[1]);

    return new WindChill(airTemp, windSpeed);
}
```

Our theory contains two sets of data, so let's comment out the one we're not working on and run our tests.

```cs
[Theory]
[InlineData("-10", "20")]
// [InlineData("32", "10", "-f", "-m")]
```

That works well, so let's uncomment the second set of data and run our tests again. This time, our test will fail because we're not handling the flags yet, and the WindChill constructor is treating the input numbers as Celsius and km/h.

Let's add to our builder.

```cs
public static WindChill Build(string[] args)
{
    double airTemp = double.Parse(args[0]);
    double windSpeed = double.Parse(args[1]);
    if (args.Length > 2)
    {
        // A bit of a cheat, but we'll fix it later
        return new WindChill(airTemp, 'F', windSpeed, "m/h");
    }
    else
    {
        return new WindChill(airTemp, windSpeed);
    }
}
```

Now, our tests pass again. We'll get into fixing our cheat once we take a look at what are invalid inputs.

### Handling Invalid Inputs

There are a lot of ways that our inputs can be invalid. We'll start with the easy ones.

| Reason             | Invalid Inputs             |
| :----------------- | :------------------------- |
| Too few arguments  | `["-10"]`                  |
| Too many arguments | `["32", "10", "-f", "-f"]` |

Hey! This is looking a *lot* like the checks we made in our driver code! Notice that I've decided to use the `FormatException` for both of these cases. I could have used an `IndexOutOfRangeException` for the first case, but I think the `FormatException` is more descriptive for reasons.

Let's create another test for these invalid inputs. Again, we will use a theory to test multiple inputs, but we'll comment out the second input.

```cs
[Theory]
[InlineData("Too few arguments", "-10")]
// [InlineData("Too many arguments", "32", "10", "-f", "-m", "extra")]
public void Reject_Invalid_Arguments(string expectedReason, params string[] args)
{
    // Arrange
    Action act = () => WindChill.Build(args);
    // Act
    // Assert
    act.Should().Throw<Exception>().WithMessage(expectedReason);
}
```

We have an exception happening, but it's not the message we expected.

> *Expected exception message to match the equivalent of "Too few arguments", but "Index was outside the bounds of the array." does not.*

Let's add the following into our builder as a guard clause.

```cs
if(args.Length < 2)
    throw new FormatException("Too few arguments");
```

Now, our test passes. Let's uncomment the second set of data and run our tests again. This time, we get a different reason for our test failing.

> *Expected a `<System.Exception>` to be thrown, but no exception was thrown.*

Let's add another guard clause to our builder.

```cs
if(args.Length > 4)
    throw new FormatException("Too many arguments");
```

That looks good. Let's see if we can expand on our set of potential invalid inputs.

|       | Reason                                             | Invalid Inputs             |
| :---: | :------------------------------------------------- | :------------------------- |
|   ✓   | Too few arguments                                  | `["-10"]`                  |
|   ✓   | Too many arguments                                 | `["32", "10", "-f", "-f"]` |
|       | The input string '-f' was not in a correct format. | `["-10", "-f"]`            |

We'll add another theory to our test class.

```cs
[InlineData("The input string '-f' was not in a correct format.", "-10", "-f")]
```

When we run the test, lo and behold, it passes! That's because we're using the `double.Parse` method, which is throwing the `FormatException`. I (sneakily) used the exception message that the `double.Parse` method throws. It looks like we're going to be OK with our builder rejecting non-numeric inputs for air temp and wind speed. But let's add another test case just to be sure.

```cs
[InlineData("The input string 'bob' was not in a correct format.", "bob", "20")]
```

It's time to address the flags as potential invalid input. Here's our new test data.


|       | Reason                                              | Invalid Inputs              |
| :---: | :-------------------------------------------------- | :-------------------------- |
|   ✓   | Too few arguments                                   | `["-10"]`                   |
|   ✓   | Too many arguments                                  | `["32", "10", "-f", "-f"]`  |
|   ✓   | The input string '-f' was not in a correct format.  | `["-10", "-f"]`             |
|   ✓   | The input string 'bob' was not in a correct format. | `["bob", "20"]`             |
|       | Unrecognized flag '-x'                              | `["-10", "20", "-x"]`       |
|       | Unrecognized flag '-x'                              | `["-10", "20", "-f", "-x"]` |

And here are the additional theory inputs.

```cs
[InlineData("Unrecognized flag '-x'", "-10", "20", "-x")]
[InlineData("Unrecognized flag '-x'", "-10", "20", "-f", "-x")]
```

Both fail with the message *Expected a `<System.Exception>` to be thrown, but no exception was thrown.*

To help our builder check those flags, we'll create a little private method.

```cs
private static void CheckFlag(string flag)
{
    if(flag != "-f" && flag != "-m")
        throw new ArgumentException($"Unrecognized flag '{flag}'");
}
```

And we'll modify our builder method to check that the flags are valid.

```cs
public static WindChill Build(string[] args)
{
    if(args.Length < 2)
        throw new FormatException("Too few arguments");
    if(args.Length > 4)
        throw new FormatException("Too many arguments");
    double airTemp = double.Parse(args[0]);
    double windSpeed = double.Parse(args[1]);
    if (args.Length > 2)
    {
        CheckFlag(args[2]);
        CheckFlag(args[3]);
        return new WindChill(airTemp, 'F', windSpeed, "m/h");
    }
    else
    {
        return new WindChill(airTemp, windSpeed);
    }
}
```

Our tests pass. Let's do a little bit of refactoring to pull our guard clause checks to the top.

```cs
public static WindChill Build(string[] args)
{
    // Guard clauses
    if(args.Length < 2)
        throw new FormatException("Too few arguments");
    if(args.Length > 4)
        throw new FormatException("Too many arguments");
    if(args.Length > 2)
        CheckFlag(args[2]);
    if(args.Length > 3)
        CheckFlag(args[3]);

    double airTemp = double.Parse(args[0]);
    double windSpeed = double.Parse(args[1]);
    if (args.Length > 2)
        return new WindChill(airTemp, 'F', windSpeed, "m/h");
    else
        return new WindChill(airTemp, windSpeed);
}
```

We could add a whole host of other tests, but I think we've covered the basics. If you think of anytning else that would be good to test, go ahead and add it.

### Revisiting The Driver

Since our builder is addressing the question of the number of parameters and dealing with invalid arguments and flags by throwing exceptions, we can do a *lot* to simplify our driver. To begin, we'll remove our `HasCorrectArgCount()` method and then wrap our call to `WindChill.Build()` in a `try`/`catch` block. Here's the new driver (*sans* the helper methods).

```cs
using static System.Console;
using static WindChill.WindChill;
WriteLine("Hello, Wind-Chill!");

int exitCode = 0;
if (HasHelpArg())
    ShowHelp();
else
{
    try
    {
        var windChill = Build(args);
        ForegroundColor = ConsoleColor.Green;
        WriteLine(windChill);
    }
    catch(Exception ex)
    {
        exitCode = ProcessError(ex.Message);
        ShowHelp();
    }
    finally
    {
        ResetColor();
    }
}
return exitCode;
```

With all of that in place, we can test our application in the console.

## Conclusion

We've got our first version of our WindChill CLI. Along the way, we've learned a lot about unit testing and other ways to make our code more robust. You might see some flaws in our code or room for improvement (I know *I* do). All of those can be addressed in future versions of our application.
