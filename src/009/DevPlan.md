# Development Plan

The overall goal of this application is to present Weather data from a file and append weather recordings to the same file. To do this, we'll make use of a class library to hold the "heart" of the system and a Blazor web application to act as the front end. We'll also create a quick console front end to act as a CLI for some simple manual interactions with the system.

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

- **ViewHistoricalWeather.razor** which will be used to present a listing of all the data read from the file.
- **RecordLocalWeather.razor** which will be used to enter information that can be appended to the file.

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
