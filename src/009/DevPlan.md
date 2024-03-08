# Development Plan

The overall goal of this application is to present Weather data from a file and append weather recordings to the same file. To do this, we'll make use of a class library to hold the "heart" of the system and a Blazor web application to act as the front end. We'll also create a quick console front end to act as a CLI for some simple manual interactions with the system.

> If you're having trouble following along with this demo project, see the [dev tips](#dev-tip-incremental-development-and-sandbox-projects) in the appendix to this document. Also, it's advised that you *journal* your development experience; writing down what you're learning and what trouble-shooting you've had to do will be a valuable resource as you progress through this course. Remember, in software development, all your learning is *cumulative*.

## Project Setup

```ps
dotnet new gitignore
dotnet new sln -n WeatherSystem
dotnet new classlib -n WeatherSystem -o WeatherLibrary
dotnet new console -n WeatherCLI -o WeatherConsole
dotnet new blazor -n WebApp -o Website -e
dotnet sln add WeatherLibrary/WeatherSystem.csproj
dotnet sln add WeatherConsole/WeatherCLI.csproj
dotnet sln add Website/WebApp.csproj
```

To connect the various project dependencies, I can do the following.

```ps
# cd to the WeatherConsole folder
dotnet add reference ../WeatherLibrary/WeatherSystem.csproj
```

```ps
# cd to the Website folder
dotnet add reference ../WeatherLibrary/WeatherSystem.csproj
```

## Project Components

The front end of the web application will consist of two primary pages:

- [**ViewHistoricalWeather.razor**](#viewhistoricalweatherrazor-component) which will be used to present a listing of all the data read from the file.
- [**RecordLocalWeather.razor**](#recordlocalweatherrazor-component) which will be used to enter information that can be appended to the file.

The `WeatherSystem` itself will consist of the following data types:

- `Location` (a POCO) to represent the place to which the weather data relates
- `Weather` (a DTO) to represent each individual weather recording, enhanced with the ability to determine wind chill effects of cold weather
- `WindChill` (a CBO) to perform wind chill calculations based on the given temperature and air speed

In addition, the `WeatherSystem` will need some classes that allow access to the data. At first, the data will come from plain CSV files, but later we will make use of a database of weather information.

## Automated Tests

Typically, we would use a TDD process to build the system using automated tests to guide our understanding of the requirements of our application. Additionally, the tests would give us a sense of confidence in the stability of our system as we move forward and make adjustments in the face of changing requirements. We won't be following TDD strictly in this example, but we will make use of it in key areas.

One of those key areas has to do with reading and writing the information from the CSV files. Because this will involve having to generates lines of CSV as well as parse those lines back into our POCO/DTO classes, a good approach is to ensure our `.Parse()` and `.ToString()` methods correctly "round-trip" the data. In other words, if I can use a CSV string as the basis for parsing and generating my DTO/POCO instances, then calling the `.ToString()` on those objects should generate the original CSV string.

To include a project to test the heart of our system, we'll run the following from the folder that holds our `.sln`

```ps
dotnet new xunit -n WeatherSystem.Specs -o WeatherLibrary.Specs
cd WeatherLibrary.Specs
dotnet add reference ../WeatherLibrary/WeatherSystem.csproj
dotnet add package FluentAssertions
```

I'll include the unit test project in my solution

```ps
dotnet sln add WeatherLibrary.Specs/WeatherSystem.Specs.csproj
```

----

## DateTime Formatting

The timestamp for the weather reports is in the format `"yyyy-MM-ddTHH:mm"`. For example, the value `"2024-01-30T00:00"` refers to January 30, 2024 at the very start of the day (i.e.: midnight).

Here's a discussion I had with Microsoft Copilot about converting strings to and from `DateTime` in C# while maintaining a consistent format.

> ![Me](./Images/Copilot-Me.png)
>
> Imagine I have a string "2024-01-30T00:00" and I want to parse it into a `DateTime` in C#. Then imagine that I want to convert it back into a string in the same format. What would my code look like?
>
> ![AI](./Images/Copilot-AI.png)
>
> Certainly! To parse the string "2024-01-30T00:00" into a `DateTime` in C#, you can use the `DateTime.ParseExact` method. Let's break down the steps:
>
> 1. **Parsing the String to DateTime**:
>
>    You'll specify the expected format of the input string using a format string. In your case, the format is "yyyy-MM-ddTHH:mm". Here's how you can do it:
>
>     ```csharp
>     using System;
>
>     class Program
>     {
>         static void Main()
>         {
>             string inputString = "2024-01-30T00:00";
>             string format = "yyyy-MM-ddTHH:mm";
>
>             if (DateTime.TryParseExact(inputString, format, null, DateTimeStyles.None, out DateTime parsedDateTime))
>             {
>                 Console.WriteLine($"Parsed DateTime: {parsedDateTime}");
>             }
>             else
>             {
>                 Console.WriteLine("Invalid input format.");
>             }
>         }
>     }
>     ```
>
>    This code snippet will parse the input string into a `DateTime` object. If successful, it will print the parsed date and time.
>
> 2. **Converting Back to String in the Same Format**:
>
>    To convert the `DateTime` back to a string in the same format, you can use the `ToString` method with the desired format:
>
>     ```csharp
>     string formattedDateTime = parsedDateTime.ToString(format);
>     Console.WriteLine($"Formatted DateTime: {formattedDateTime}");
>     ```
>
>    This will give you the string "2024-01-30T00:00" again.
>
> Remember to adjust the format string if your input string has additional components (such as seconds or milliseconds). The `DateTimeStyles.None` parameter ensures that no additional adjustments are made during parsing.
>
> Feel free to customize the code according to your specific needs! 🕰️📅
>
> Source: Conversation with Bing, 2024-03-06
>
> (1) Convert strings to DateTime - .NET | Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime.
>
> (2) Convert time string to DateTime in c# - Stack Overflow. https://stackoverflow.com/questions/36122397/convert-time-string-to-datetime-in-c-sharp.
>
> (3) How to parse strings to DateTime in C# properly? - Stack Overflow. https://stackoverflow.com/questions/5366285/how-to-parse-strings-to-datetime-in-c-sharp-properly.
>
> (4) C# - Parsing a DateTime from a string | MAKOLYTE. https://makolyte.com/csharp-parsing-a-datetime-string-with-a-custom-format/.
>
> (5) c# - Converting a String to DateTime - Stack Overflow. https://stackoverflow.com/questions/919244/converting-a-string-to-datetime.
>
> ----
>
> ![Me](./Images/Copilot-Me.png)
>
> When you call `parsedDateTime.ToString(format)`, what should the value of `format` be in order to get an output that matches a date-time like "2024-01-30T00:00"? Also, is there a name for that kind of format for date-time?
>
> ![AI](./Images/Copilot-AI.png)
>
> Certainly! To get an output in the format "2024-01-30T00:00", you should set the value of `format` to `"yyyy-MM-ddTHH:mm"`.
>
> This format is known as the **ISO 8601** date and time format. It's widely used for representing date and time information in a standardized way, especially in contexts like XML, JSON, and APIs. The "T" in the format separates the date part from the time part, and the colons (":") indicate the hours and minutes.
>
> Feel free to use this format for consistent and interoperable date-time representations! 🕰️📅

----

## Blazor Pages

To begin, let's create two Blazor components inside our `Pages` folder and name them **`ViewHistoricalWeather`** and **`RecordLocalWeather`**. Then, to ease our access to these pages, let's add some navigation links in our site, using route paths that match our component names (for ease of recognition).

### `ViewHistoricalWeather.razor` Component

> I'm going to use Microsoft's [QuickGrid Component](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/quickgrid?view=aspnetcore-8.0), which means that I will need to run the following to add the NuGet package for that component.
>
> ```ps
> dotnet add package Microsoft.AspNetCore.Components.QuickGrid
> ```

When it comes to viewing the historical weather, we have a few interesting concerns. The first has to do with determining the *path* for the data we need to load. Once we have the data, then we need to know how to process the *location* that the weather data relates to. Lastly, we need to deal with the *volume* of weather related data, as it may be more than what our user wants to see.

#### Hosting Our Data

Most of the time, we will find that our data resides in a database. In this case, by virtue of having our data inside of CSV files, we are likely to have our files on the same server that hosts our web application.

Create a folder named `Data` inside of the `Website` folder. Then, place a copy of the CSV file we're using for our weather data.

In our example, we will provide a drop-down for the user to select the file that holds our data.

> *TODO: expand on notes*

#### Location, Location, Location

The first regards the *location* that the weather data relates to. We have a set of Lat./Long. values, but no "name" for the location. How will we indicate that to the user?

For this, we'll make use of [**Leaflet**](https://leafletjs.com/examples/quick-start/), an open-source and free JavaScript library that leverages Open Street Map.

> ~~*Instructions to follow*~~ - **Defer for later** - JsInterop can be tricky....

#### Too Much Data!

Our existing CSV file has over 300 rows of weather data, calibrated at an hour-by-hour set of measurements. That's way too much to show in a single table.

For our purposes, we'll filter the data by presenting the user with a Date input where they can choose a specific day. In response, we'll show the hourly temperature information for that day in a nice tabular form. For a little bling, we'll even make use of some of the [Line-Awesome weather icons]().

- `<i class="las la-wind"></i>`
- `<i class="las la-temperature-high"></i>`
- `<i class="las la-temperature-low"></i>`
- `<i class="las la-mitten"></i>`

### `RecordLocalWeather.razor` Component

----

## Appendix

### Dev Tip: Incremental Development and Sandbox Projects

One important key to success when writing software is to **develop in small steps**. This is especially important when you're dealing with code/technology that is "new-to-you".

This approach of small steps might take some planning. For example, in this Blazor app it makes sense to start out with your navigation system and near-empty pages for each part you have to build. This will allow you to switch back-and-forth among the pages of your system and know that they are loading properly. Next, pick a single part of just one of the pages and get it working. Don't worry about displaying or getting input for the complete data model your page is working with; just pick some small pieces of the model. If you need to temporarily hard-code values into the page in order to focus on that small part, go right ahead and do that.

> When building the Blazor application, you can have the website running as you build each feature, one at a time. From the terminal, run **`dotnet watch`** to compile and launch your application. Within the terminal, you can always press <kbd>ctrl</kbd> + <kbd>r</kbd> to rebuild your application; the rebuild will effectively "reset" your web page to its first load.

If you find yourself hitting roadblocks that leave you spinning your wheels for a while, then it's probably a sign that you are either trying to get things working in chunks that are too big or that you have some misconceptions about how some parts of code/technology actually works. This is where it's helpful to create ***ultra simple* sandbox projects** to play with the technology/concept you are wrestling with. In terms of Blazor, there's a lot of under-the-hood pieces in play. If you are new to web *application* development, then create a separate Blazor app that is "bare-bones" (absolutely no styling) where you can dedicate separate pages for the individual pieces you are struggling to understand. The idea here is to **isolate the problem** that you are having. By separating your problem area from other moving parts, you have a better chance of discovering key concepts and understanding how things work.

Another thing that can be helpful is to tie things back into what you are already comfortable with (which is why we're including a console app in this sample solution). The console gives a basic "proof-of-concept" for the internals of the app: Can we properly handle (parse) the data we've been supplied with? Can we read from and write to the data store?

### Troubleshooting

> Add your own tips, diagnosis and solutions here...

#### `<InputDate>` Component

Regarding getting input for date and time from the `<InputDate>` component, my first attempt resulted in only having an input control that allowed me to select the date, but not the time. So, I turned to Bing AI.

> ![AI](./Images/Copilot-AI.png)
>
> Certainly! Let's explore how to handle date and time input in Blazor WebAssembly using the `InputDate<TValue>` component. Blazor WebAssembly is part of the .NET ecosystem, and it allows you to build web applications using C# and Razor syntax.
>
> 1. **Using Built-in Blazor Form Input Component (Starting from .NET 6)**:
>    Starting from .NET 6, you can use the built-in `InputDate` component to handle both date and time input. Here's an example of how to use it:
>
>     ```razor
>     <InputDate Type="InputDateType.DateTimeLocal" @bind-Value="@dateTime" />
>     @code {
>         DateTime dateTime;
>     }
>     ```
>
>     The `InputDateType.DateTimeLocal` option allows users to enter both a date and a time. You can also set a minimum date using the `min` attribute, as shown above¹.
>
> 2. **Setting an Initial Value**:
>    To set an initial value for the date, simply initialize the `dateTime` property when creating the value. For instance:
>
>     ```csharp
>     Meetings meeting = new Meetings
>     {
>         Date = DateTime.Today
>     };
>     ```
>
> 3. **Custom Formatting**:
>    If you want to format the date display, you can use the `@bind:format` attribute. For example:
>
>     ```razor
>     <input bind="Model.Date1" @bind:format="dd-MM-yyyy" class="form-control" />
>     ```
>
>     This will display the date in the "dd/MM/yyyy" format².
>
> 4. **Third-Party Components**:
>    If you need more advanced features, consider using third-party components like the **Syncfusion Blazor DateTimePicker**. Here's how you can add it to your Blazor application:
>
>     ```razor
>     <SfDateTimePicker TValue="DateTime?" Placeholder="Select a date and time"></SfDateTimePicker>
>     ```
>
>     Make sure to include the necessary dependencies and follow the documentation for further customization³.
>
> Remember that the `InputDate<TValue>` component is a powerful tool for handling date and time input in your Blazor applications. Whether you choose the built-in component or a third-party library, it's essential to provide a seamless user experience for date and time selection! 📅⏰
>
> Source: Conversation with Bing, 2024-03-07
>
> (1) c# - Taking DateTime input in Blazor WASM - Stack Overflow. https://stackoverflow.com/questions/63853562/taking-datetime-input-in-blazor-wasm.
>
> (2) How to format <InputDate> to "dd/MM/yyyy" in Blazor Webassembly. https://stackoverflow.com/questions/72097858/how-to-format-inputdate-to-dd-mm-yyyy-in-blazor-webassembly.
>
> (3) Getting Started with Blazor DateTimePicker Component. https://blazor.syncfusion.com/documentation/datetime-picker/getting-started.
>
> (4) ASP.NET Core Blazor input components | Microsoft Learn. https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/input-components?view=aspnetcore-8.0.
>
> (5) undefined. https://learn.microsoft.com/en-us/aspnet/core/blazor/components/data-binding?view=aspnetcore-8.0.

Sweet! Now I know about using the `Type` attribute on the `<InputDate>` where I can select from any of the [`InputDateTime` enum values](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.inputdatetype?view=aspnetcore-8.0).
