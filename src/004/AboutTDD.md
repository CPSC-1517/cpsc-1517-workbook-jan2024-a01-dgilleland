# Intro to Test-Driven Development

> ***Note:** This introduction presumes that you are already familiar with C# syntax regarding classes and with how to perform simple calculations.*

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

One of the early ways developers tried to address this uncertainty was through the use of **Automated Tests**. Creating automated tests is a practice where we write code that tests our code. That is, we create code (*tests*) that embody the expectations (or *specifications*) about how our production code should work. We then run those tests to see if our code works the way we want it to. If it does, then we can be more confident that our code is working. If it doesn't, then we know we need to fix our code.

The big benefit of automated tests is that it's much *faster* to run an automated test suite to check for errors than it is to manually test our code. Not only is it much faster, it's a whole lot more *consistent* than relying upon manual tests. Because we can run all of our tests at once, we can be more *thourough* in our testing. All of this helps us to create new code with more confidence.

But automated tests don't just help with creating new code. They also help with *maintaining* our code. As we make changes to one part of our code, we can run our tests to make sure that our changes don't break anything else. This is especially important when we're making changes to code that already works. We want to make sure that our changes don't have unintended consequences. This is called **Regression Testing**. Regression Testing is the practice of running all of our tests to make sure that our existing codebase still works after we've made changes to some other part of our codebase.

### Types of Tests

There are different kinds of automated tests. One of the oldest and best known are **Unit Tests**. Unit tests focus on a small unit of functionality for our code base. For example, we might have a unit test that checks to see if a method returns the correct value. Or we might have a unit test that checks to see if a method throws an exception when given bad inputs or run under faulty conditions.

Unit tests are great for testing small units of functionality, but they're not so great for testing larger units of functionality. For that, we need a different kind of test: **Integration Tests**. Integration tests are used to test larger units of functionality, particularly when they cross some sort of *processing boundary*.

In turn, while integration tests are great for testing larger units of functionality, but they're not so great for testing the entire breadth of an application. For that, we need **End-to-End Tests**.

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
| :-----------: | :---------------: | :--------: |
|      -10      |        20         |  -17.855   |

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

### Our First Test

For our first test, we'll focus on what's required to simply create a `WindChill` object. With that, we'll be able to satisfy one of our requirements:

> - [ ] Retain knowledge of the set of conditions for the calculated wind chill (even *after* the calculation is complete).

Upon instantiating our object, we will check that the values we supplied for `AirTemperature` and `WindSpeed` have been properly stored in the object's properties.

First, let's frame our test. A common pattern in unit tests is the Triple-A pattern: *Arrange*, *Act*, and *Assert*. We'll build our test in small steps. Here's our unit test. Note that since we don't yet have a `WindChill` class, we'll be getting a compilation error at the *Act* step.

```cs
[Fact] // Annotation that identifies this as a test
public void Construct_With_AirTemperature_And_WindSpeed()
{
    // Arrange - Setup our test condition
    double givenTemp = -10, givenWind = 20;

    // Act - What it is that we are testing
    // - sut - System Under Test
    WindChill sut = new(givenTemp, givenWind);

    // Assert - Does it do what it should
    sut.AirTemperature.Should().Be(givenTemp);
    sut.WindSpeed.Should().Be(givenWind);
}
```

To solve this, we'll create our class inside our console application. Here's the first pass.

```cs
namespace WindChill;

public class WindChill
{
    public WindChill(double airTemp, double windSpeed)
    {
    }
}
```

Our *Act* step now compiles. But without the properties in place, our *Assert* portion will not compile. Let's fix that.


```cs
namespace WindChill;

public class WindChill
{
    public double AirTemperature { get; set; }
    public double WindSpeed { get; set; }
    public WindChill(double airTemp, double windSpeed)
    {
    }
}
```

Everything now compiles! Let's run the test. In VS Code, press <kbd>ctrl</kbd> + <kbd>;</kbd>, and then press the <kbd>a</kbd> key. Our test will run, but will fail with the following error.

> *Expected sut.AirTemperature to be -10.0, but found 0.0 (difference of 10).*

We can fix that by storing the `airTemp` into the corresponding property via the constructor.

```cs
AirTemperature = airTemp;
```

Running our test again, this time the `WindSpeed` value fails our test.

> *Expected sut.WindSpeed to be 20.0, but found 0.0 (difference of -20).*

Let's complete the constructor.

```cs
public WindChill(double airTemp, double windSpeed)
{
    AirTemperature = airTemp;
    WindSpeed = windSpeed;
}
```

Our first test passes. On to the next!

> - [x] Retain knowledge of the set of conditions for the calculated wind chill (even *after* the calculation is complete).

### Ensuring Default Units

We have the requirement that our class use Celsius and km/h as the default units of measurement.

> - [ ] Be biased toward using the *Celsius* scale for *Air Temperature* and *km/h* for *Wind Speed* (unless otherwise directed).

We know as well that we will be supporting other units of measurement as well (more on that later). One of the implications we can draw from this is that we will need to store the units of measurement for both the *Air Temperature* and *Wind Speed* values. Let's write a pair of tests to make reflect these insights.

First up, we will test for the air temperature units. Here's our test.

```cs
[Fact]
public void Use_Celsius_If_Not_Specified()
{
    // Arrange
    WindChill sut = new(-10, 20);
    // Act
    var actual = sut.TemperatureUnits;
    // Assert
    actual.Should().Be('C');
}
```

Again, we can see that we don't have a `TemperatureUnits` property. From our test, you should be able to deduce that the property should be a `char` type. Let's add that to our class.

```cs
public char TemperatureUnits { get; set; }
```

Our code compiles, but running our tests shows that this test fails. There are several ways we could fix that. Let's use the simplest, which is to give the property a default value.

```cs
public char TemperatureUnits { get; set; } = 'C';
```

Great! On to testing the wind speed units.

```cs
[Fact]
public void Use_KmPerHour_If_Not_Specified()
{
    // Arrange
    WindChill sut = new(-10, 20);
    // Act
    string actual = sut.WindSpeedUnits;
    // Assert
    actual.Should().Be("km/h");
}
```

Again, we will have to fix both the compilation error and the test failure. You can probably guess what the solution would look like. Add the following property to the `WindChill` class.

```cs
public string WindSpeedUnits { get; set; } = "km/h";
```

> - [x] Be biased toward using the *Celsius* scale for *Air Temperature* and *km/h* for *Wind Speed* (unless otherwise directed).

### What it Feels Like

With our basic inputs in place, we can move on to the heart of our application: Determining the wind chill. We had two requirements related to this functionality.

> - [ ] Be able to calculate the wind chill for a given set of conditions (*Air Temperature* and *Wind Speed*).
> - [ ] Represent the entire result in a meaningful way (i.e.: as a simple formatted string).

We'll start with the simplest test we can think of: What does the temperature feel like when the air temperature is -10°C and the wind speed is 20km/h? Here's a test to check that.

```cs
[Fact]
public void Calculate_Wind_Chill_Using_Default_Units()
{
    // Arrange
    WindChill sut = new(-10, 20);
    double expected = -17.855; // From our table of test data
    // Act
    var actual = sut.FeelsLike;
    // Assert
    actual.Should().Be(expected);
}
```

Before you go reaching for that formula to perform the calculations, I want to interject a sometimes overlooked principle in taking a Test-Driven Design approach to software: Coding for the simplest solution to our tests. In this case, we're going to take a shortcut and just return the expected value. You might think we're cheating (and we kinda are), but later on we'll encounter other behaviour of our `WindChill` class that will drive us to where we ultimately want to be. For now, just create a simple field with the value we want.

```cs
public double FeelsLike = -17.855;
```

Now, let's move on to the test for the string representation of our wind chill. We'll use the same test data as before, and we'll expect our class to implement the `ToString()` method.

```cs
[Fact]
public void Represent_WindChill_As_Text()
{
    // Arrange
    string expected = $"-10{'\u00B0'}C at 20km/h feels like -17.855{'\u00B0'}C";
    var sut = new WindChill(-10, 20);
    // Act
    string actual = sut.ToString();
    // Assert
    actual.Should().Be(expected);
}
```

Again, we'll take a shortcut and just return the expected value.

```cs
public override string ToString()
{
    return $"-10{'\u00B0'}C at 20km/h feels like -17.855{'\u00B0'}C";
}
```

> - [x] Be able to calculate the wind chill for a given set of conditions (*Air Temperature* and *Wind Speed*).
> - [x] Represent the entire result in a meaningful way (i.e.: as a simple formatted string).

With our tests passing, let's move on to the question of validating our input.

### Validating Input

Let's apply a bit of sanitation to our code. We want to put some limits on our choices for the *Air Temperature* and *Wind Speed* values.

> - [ ] Require temperatures to be below freezing.
> - [ ] Require wind speeds to be between 10 and 70km/h

We'll start with the *Air Temperature*. Here's our test.

```cs
[Fact]
public void Reject_Temperature_Above_Freezing()
{
    // Arrange
    Action act = () => new WindChill(1, 20);
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>();
}
```

Notice that we've got something entirely new here: the `Action` data type. An *`Action`* is a type of delegate - a representation of some method that that can be called on our behalf by some other part of the codebase. Notice also the value we're assigning to our `Action` variable, `act`. We're using a *lambda expression* to create an anonymous method that will create a new `WindChill` object. Essentially, the `act` variable is a reference to a method that will create a `WindChill` object.

Why are we doing that? Well, the reason is that we want to make sure our `WindChill` constructor will reject an invalid air temperature. That rejection should take the form of an exception (specifically, an `ArgumentOutOfRangeException`). But all of this puts us in a catch-22 situation. How can we call the constructor, and then perform an assertion on the exception?

One approach would be to wrap the constructor call in a `try/catch` block. But that's not very elegant.Instead, we can use the `Should().Throw<>()` method to check that our code throws an exception when we try to create the object. That's why we need an `Action` variable - to "defer" our actual creation of the object until the `Should().Throw<>()` method is called.

This is a common pattern in unit testing potential exceptions. While I would never expect you to come up with this approach on your own, it's good for you to take note of it here for the future.

That's enough of an aside for now. Let's run our test. When we do so, we get the following failure.

> *Expected a `<System.ArgumentOutOfRangeException>` to be thrown, but no exception was thrown.*

How will we make our test pass? The most straight-forward approach is to add a check to our constructor that will throw an exception if the air temperature is above freezing. Here's our updated constructor.

```cs
public WindChill(double airTemp, double windSpeed)
{
    if (airTemp > 0)
    {
        throw new ArgumentOutOfRangeException(nameof(airTemp), "Air temperatures above freezing are not allowed");
    }
    AirTemperature = airTemp;
    WindSpeed = windSpeed;
}
```

When we run our test, everything passes. Before we move on, take another gander at the constructor's implementation. Our test of the `airTemp` value is the first thing we do: If the value is invalid, we throw an exception. Note that we don't need an `else` clause to our `if` statement. Throwing the exception would cause our constructor to exit immediately. That means that the rest of the code in the constructor will not be executed. This is a common pattern in unit testing: We want to test for the invalid values first, and then we can assume that the values are valid for the rest of the code. These kinds of validations are called **Guard Clauses**.

Let's move on to the wind speed. We'll need two tests (one for the lower limit and one for the upper limit). Here's our next test. This time, I've included a little "extra" for our test: I'll be expecting the exception to contain a particular bit of text in its description of the exception.

```cs
[Fact]
public void Reject_WindSpeed_Below_10kph()
{
    // Arrange
    Action act = () => new WindChill(0, 9.99999);
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speeds below 10 kph are not allowed*");
}
```

Notice the use of the asterixes in the message. These represent *wild cards* in the check for the message. When our constructor throws the exception, the `WithMessage()` method will check to see if the message contains the text we've specified. If it does, then our test will pass. If it doesn't, then our test will fail.

As you might imagine, we can simply add another guard clause to our constructor. Here's the code.

```cs
public WindChill(double airTemp, double windSpeed)
{
    if (airTemp > 0)
    {
        throw new ArgumentOutOfRangeException(nameof(airTemp), "Air temperatures above freezing are not allowed");
    }
    if (windSpeed < 10)
    {
        throw new ArgumentOutOfRangeException(nameof(windSpeed), "Wind speeds below 10 kph are not allowed");
    }
    AirTemperature = airTemp;
    WindSpeed = windSpeed;
}
```

Now, let's test for the upper limit.

```cs
[Fact]
public void Reject_WindSpeed_Over_70kph()
{
    // Arrange
    Action act = () => new WindChill(0, 71);
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speeds above 70 kph are not allowed*");
}
```

Can you create the code to make that test pass? I'll leave it up to you to figure that out. Once you're done, you'll have a `WindChill` class that filters out unwanted input.

> - [ ] Require temperatures to be below freezing.
> - [ ] Require wind speeds to be between 10 and 70km/h

### Time for Real Math

It's time to get a little more serious about our calculations of the wind speeds.

Our single test for the wind chill in °C was easy to pass by just returning the expected value. But we should remember that the formula is using exponents (e.g.: $T^{0.16}$) and other fractional values (e.g.: $0.6215$). Unless we employ precise rounding at certain points of our calculations, we'll probably get some failed tests. Therefore, we'll use some *approximations* in our tests. Generally speaking, it should be sufficient enough to look for temperature results that are rounded to a tenth of a degree (regardless of the units).

Additionally, we need to deal with the English units of **°F** and **m/h**. We could hand-calculate the values, or we can take another look to see if there's a reliable online calculator for wind chill. I found a good one, this time from the [**National Weather Service**](https://www.weather.gov/epz/wxcalc_windchill) (which presumably would be a good resource). Let's re-populate our table of test data from earlier.

| Air Temp (°C) | Wind Speed (km/h) | Wind Chill |
| :-----------: | :---------------: | :--------: |
|      -10      |        20         |   -17.9    |

| Air Temp (°F) | Wind Speed (m/h) | Wind Chill |
| :-----------: | :--------------: | :--------: |
|      32       |        10        |    23.7    |

Obviously, we're going to have to go back and fix our tests for the Celsius calculations and the `.ToString()` implementations. But let's start with the English units.

### Handling English Units

> I've referred to the use of Farenheit and miles-per-hour as English units, simply because they originated in Europe. It might be more accurate to refer to these as the *Imperial* units of measurement, since they originated out of the British Empire. Some refer to them as *American* units, since the US is one of the very few countries that still use them. But I digress. Let's get back to our tests.

Supporting alternate sets of units is going to introduce some challenges to our program, in part because we're going to have to think about how that might affect our earlier tests. Here's our requirement.

- [ ] Be able to handle different units of measurement for the *Air Temperature* and *Wind Speed* (i.e.: Farenheit and miles per hour).

Let's start with testing the temperature in °F.

```cs
[Fact]
public void Represent_Temperature_As_Farenhiet()
{
    // Arrange
    WindChill sut = new(32, 'F', 10, "m/h");

    // Act
    var actualTemp = sut.AirTemperature;
    var actualUnits = sut.TemperatureUnits;

    // Assert
    actualTemp.Should().Be(32);
    actualUnits.Should().Be('F');
}
```

This time, I've bundled a couple of assertions into a single test method. Developers can debate the merits of this approach, but for now, let's just go with it. I suspect we might need to come back and do a lot of refactoring of our tests in the near future, so taking liberties with our tests is probably not a big deal at the moment.

Notice here that we have a new constructor, one that takes four arguments. We'll need to add that to our `WindChill` class.

```cs
public WindChill(double airTemp, char airTempUnits, double windSpeed, string windSpeedUnits)
{
}
```

Our test fails, so let's fix that (in the easiest way possible).

```cs
public WindChill(double airTemp, char airTempUnits, double windSpeed, string windSpeedUnits)
{
    AirTemperature = airTemp;
    TemperatureUnits = airTempUnits;
}
```

Looks good so far, but there's something that should cause us to stop and ponder what we're doing.

With two constructors in play, we should give some thought to how we want to handle the different constructors. After all, both constructors should help us set up a valid WindChill object, and a constructor's sole purpose is to make sure that all the parameters/fields have meaningful values. How are we going to do that?

We could duplicate our code, copying what we already have in our two-parameter constructor into our four-parameter constructor. But that's going to result in some extra maintenance along the way. That's not a long term solution. Instead, let's have the two-argument constructor call the four-argument constructor, passing in our default assumptions about the units being Celsius and kilometers-per-hour. That way, we can keep all of the code that sets the properties and fields in one place. Modify your constructors to look like this.

> This approach of making one constructor call another in the same class is called **constructor chaining**. It's a common pattern in object-oriented programming.

```cs
public WindChill(double airTemp, double windSpeed)
    : this(airTemp, 'C', windSpeed, "km/h") // Call the four-argument constructor
{
    if (airTemp > 0)
    {
        throw new ArgumentOutOfRangeException(nameof(airTemp), "Air temperatures above freezing are not allowed");
    }
    if (windSpeed < 10)
    {
        throw new ArgumentOutOfRangeException(nameof(windSpeed), "Wind speeds below 10 kph are not allowed");
    }
}

public WindChill(double airTemp, char airTempUnits, double windSpeed, string windSpeedUnits)
{
    AirTemperature = airTemp;
    WindSpeed = windSpeed;
    TemperatureUnits = airTempUnits;
}
```

At present, I've got the two-argument constructor throwing the exceptions. We'll come back to that in a moment. For now, our tests are still passing, so let's move on to represent the wind speed in miles-per-hour.

```cs
[Fact]
public void Represent_WindSpeed_As_MilesPerHour()
{
    // Arrange
    WindChill sut = new(32, 'F', 10, "m/h");
    string expected = $"32{'\u00B0'}F at 10m/h feels like 23.7{'\u00B0'}F";
    // Act
    var actualUnits = sut.WindSpeedUnits;
    var actualWindSpeed = sut.WindSpeed;
    // Assert
    actualUnits.Should().Be("m/h");
    actualWindSpeed.Should().Be(10);
}
```

It's only a small change in our four-parameter constructor to set the wind speed units.

```cs
public WindChill(double airTemp, char airTempUnits, double windSpeed, string windSpeedUnits)
{
    AirTemperature = airTemp;
    WindSpeed = windSpeed;
    TemperatureUnits = airTempUnits;
    WindSpeedUnits = windSpeedUnits;
}
```

We're now capturing the units of measurement for both the air temperature and the wind speed. But we need to review our test data and our tests to make sure we're handling everything correctly.

### What's Missing

Let's revisit our test data and formally introduce a more comprehensive representation of all of our inputs and outputs. Here's a re-write that includes valid inputs and expected outputs, with some extra calculations along the way.

| Air Temp | Temp Units | Wind Speed | Speed Units | Resulting Wind Chill |
| :------: | :--------: | :--------: | :---------: | :------------------: |
|  `-10`   |            |    `20`    |             |      **-17.9**       |
|  `-10`   |    `C`     |    `20`    |   `km/h`    |      **-17.9**       |
|   `32`   |    `F`     |    `10`    |    `m/h`    |       **23.7**       |

In the table above, a blank cell indicates that we're relying upon our default units of Celsius and km/h.

We won't look at mixing the Imperial and Metric units (though our code allows it to happen). Instead, we'll focus on rewriting our last two tests to reflect the idea of being explicit in our units of measurement. First, let's replace our `Represent_Temperature_As_Farenhiet()` and `Represent_WindSpeed_As_MilesPerHour()` tests with this single test.

```cs
[Theory]
[InlineData(-10, 'C', 20, "km/h")]
[InlineData(32, 'F', 10, "km/h")]
public void Represent_WindChill_Inputs_With_Explicit_Units(double givenAir, char givenTempUnits, double givenWind, string givenWindUnits)
{
    // Arrange
    // Act
    WindChill sut = new(givenAir, givenTempUnits, givenWind, givenWindUnits);

    // Assert
    sut.AirTemperature.Should().Be(givenAir);
    sut.TemperatureUnits.Should().Be(givenTempUnits);

    sut.WindSpeed.Should().Be(givenWind);
    sut.WindSpeedUnits.Should().Be(givenWindUnits);
}
```

Notice how our single test is no longer written as a `[Fact]` but as a `[Theory]`. This is because we want the test to be true for various sets of inputs (represented in the `[InlineData]` attributes). The test runner will run the test multiple times, once for each set of inputs. The `[InlineData]` attribute tells the test runner what those inputs should be.

Because we have only rewritten our specifications (*tests*), without forcing changes on our `WindSpeed` class, our test should still pass.

### Finally! The Wind Chill Formula

We've been putting off the actual calculations for the wind chill. Let's get to it! Start by creating the following theory.

```cs
[Theory]
[InlineData(-10, 'C', 20, "km/h", -17.9)]
[InlineData(32, 'F', 10, "km/h", 23.7)]
public void Calculate_WindChill_From_Explicit_Units(double givenAir, char givenTempUnits, double givenWind, string givenWindUnits, double expectedWindChill)
{
    // Arrange
    // Act
    WindChill sut = new(givenAir, givenTempUnits, givenWind, givenWindUnits);

    // Assert
    sut.FeelsLike.Should().Be(expectedWindChill);
}
```

As you might expect, our test fails (at least for one set of inputs). That's because we had hard-coded the `FeelsLike` field along with the results of our `.ToString()` override. Let's draw our our formula and see if we can't get our tests to pass.

There are actually two sets of formulas that are available to us. Here's the first set for Celsius and km/h.

$$
13.12 + (0.6215 \times T_C) - 11.37 \times (V_k^{0.16}) + 0.3965 \times T_C (V_k^{0.16})
$$

The one for Fahrenheit and m/h is a little different.

$$
35.74 + (0.6215 \times T_F) – 35.75 \times (V_m^0.16) + 0.4275 \times T_F (V_m^0.16)
$$

To implement these formulas, we will replace our `FeelsLike` field with a `FeelsLike` property that calculates our wind chill. Here's our first pass.

```cs
public double FeelsLike 
{ 
    get
    {
        double temperature;
        if(TemperatureUnits == 'C' && WindSpeedUnits == "km/h")
        {
            // Metric Calculation
            temperature = 13.12 + 0.6215 * AirTemperature - 11.37 * Pow(WindSpeed, 0.16) + 0.3965 * AirTemperature * Pow(WindSpeed, 0.16);
        }
        else
        {
            // Imperial Calculation
            temperature = 35.74 + 0.6215 * AirTemperature - 35.75 * Pow(WindSpeed, 0.16) + 0.4275 * AirTemperature * Pow(WindSpeed, 0.16);
        }
        return Round(temperature, 1);
    }
}
```

This caused our most recent test to finally pass, but we broke an earlier test (`Calculate_Wind_Chill_Using_Default_Units()`). That's because we had a hard-coded expectation of the wind chill calculated to more decimal places. The problem lays in our test, so let's fix that with our updated data.

```cs
[Fact]
public void Calculate_Wind_Chill_Using_Default_Units()
{
    // Arrange
    WindChill sut = new(-10, 20);
    double expected = -17.9; // <== Change this line
    // Act
    var actual = sut.FeelsLike;
    // Assert
    actual.Should().Be(expected);
}
```

Wonderful! We're almost there!

Now, let's wrap up our WindChill class by testing for the desired text output.

```cs
[Theory]
[InlineData(-10, 'C', 20, "km/h", -17.9)]
[InlineData(32, 'F', 10, "km/h", 23.7)]
public void Represent_WindChill_Text_With_Explicit_Units(double givenAir, char givenTempUnits, double givenWind, string givenWindUnits, double expectedWindChill)
{
    // Arrange
    string expectedText = $"{givenAir}{'\u00B0'}{givenTempUnits} at {givenWind}{givenWindUnits} feels like {expectedWindChill}{'\u00B0'}{givenTempUnits}";
    // Act
    WindChill sut = new(givenAir, givenTempUnits, givenWind, givenWindUnits);

    // Assert
    sut.ToString().Should().Be(expectedText);
}
```

In this test, we actually get a hint at what our `.ToString()` implementation should look like. Let's implement that now.

```cs
public override string ToString()
{
    return $"{AirTemperature}{'\u00B0'}{TemperatureUnits} at {WindSpeed}{WindSpeedUnits} feels like {FeelsLike}{'\u00B0'}{TemperatureUnits}";
}
```

Once again, our most recent test passes, but we've broken an earlier test (`Represent_WindChill_As_Text()`).

```cs
[Fact]
public void Represent_WindChill_As_Text()
{
    // Arrange - Fix the expectation below
    string expected = $"-10{'\u00B0'}C at 20km/h feels like -17.9{'\u00B0'}C";
    var sut = new WindChill(-10, 20);
    // Act
    string actual = sut.ToString();
    // Assert
    actual.Should().Be(expected);
}
```

### Revisiting Input Validation

The final part of our tests into the WindChill class is to revisit our input validation. We had two tests that were checking for invalid inputs with default units. We can keep those, but we need to reconsider what those limits are for °F and m/h.

```cs
[Fact]
public void Reject_Temperature_Above_Freezing_In_Farhenheit()
{
    // Arrange
    Action act = () => new WindChill(33, 'F', 10, "m/h");
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>();
}
```

How should we handle this new limit? Again, having a guard clause is a good idea. Let's put one in our four-parameter constructor.


```cs
public WindChill(double airTemp, char airTempUnits, double windSpeed, string windSpeedUnits)
{
    if(airTempUnits == 'F' && airTemp > 32)
    {
        throw new ArgumentOutOfRangeException(nameof(airTemp), "Air temperatures above freezing are not allowed");
    }

    AirTemperature = airTemp;
    WindSpeed = windSpeed;
    TemperatureUnits = airTempUnits;
    WindSpeedUnits = windSpeedUnits;
}
```

That was pretty clean, thanks in large part to the fact that 32°F is the same as 0°C. But what about the wind speed? We had arbitrarily set our lower and upper limits to 10 and 70 km/h respectively. Their equivalents in m/h are not quite as clean, and we'll need a bit of test data for that. After checking online, I found that a low speed of 6.2 m/h and a high speed of 43.5 m/h will fall just outside of the range of acceptable values. Let's use those in our tests.

```cs
[Fact]
public void Reject_Low_WindSpeed_In_MPH()
{
    // Arrange
    Action act = () => new WindChill(14, 'F', 6.2, "m/h");
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speed is below the lower limit*");
}
```

```cs
[Fact]
public void Reject_High_WindSpeed_In_MPH()
{
    // Arrange
    Action act = () => WindChill(2, 'F', 43.5, "m/h");
    // Act
    // Assert
    act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Wind speed is above the upper limit*");
}
```

How would you write the code to pass these last two tests? I can imagine a few ways of implementing them. I'll leave it for you to figure this one out as an exercise.

----

## Conclusion

In this tutorial, we've taken a look at how we can use Test-Driven Design to create a class that calculates the wind chill. We've seen how we can use unit tests to drive the design of our class, and how we can use those tests to help us refactor our code. We've also seen how we can use the Triple-A pattern to help us organize our tests.

Our `WindChill` project served as a good sample for exploring the concepts and mechanics of Test-Driven Design. There's still more to be done, and in the next article on [Completing the WindChill CLI](./CompletingTheCLI.md) we will explore a **builder pattern** for creating our `WindChill` objects from command-line parameters.

