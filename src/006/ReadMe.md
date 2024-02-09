# Blazor 8 Intro

- [ ] Create a Blazor 8 web application (w. Bootstrap)

    ```powershell
    dotnet new blazor -o src/006/Website -n WebApp
    dotnet new sln -o src/006 -n BlazorIntro
    cd src/006
    dotnet sln add Website/WebApp.csproj
    cd Website
    ```

- [ ] Install dev certificate (and trust it) (see [these docs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs#examples))
  - *This is a one-time task on your computer*

    ```powershell
    dotnet dev-certs https --trust
    ```

- [ ] Run the blazor website (in watch mode)

    ```powershell
    dotnet watch
    ```

- [ ] Tour of the starter kit code (*quote below is from one of the [blazor tutorial](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) samples by Microsoft*)

> Several files were created to give you a simple Blazor app that is ready to run.
>
> - `Program.cs` is the entry point for the app that starts the server and where you configure the app services and middleware.
> - `App.razor` is the root component for the app.
> - `Routes.razor` configures the Blazor router.
> - The `Components/Pages` directory contains some example web pages for the app.
> - `WebApp.csproj` defines the app project and its dependencies and can be viewed by double-clicking the BlazorApp project node in the Solution Explorer.
> - The `launchSettings.json` file inside the Properties directory defines different profile settings for the local development environment. A port number is automatically assigned at project creation and saved on this file.
