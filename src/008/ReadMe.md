# Several Samples of Form Inputs

In this Blazor application, I present a series of forms to demonstrate a swath of ideas from the very basics of processing user input through HTML forms to all the different ways (*within the scope of this course*) that we can handle simple and complex forms in Blazor 8.

## What is Blazor?

Blazor is an approach in ASP.NET Core to provide AJAX or *AJAX-like* interactions between the web server and the client browser. Apart from AJAX (*Asynchronous JavaScript and XML*) and the relativly new WASM (*Web Assembly Module*) technologies, the only way web servers and client browsers communicated was through a Request/Response interaction that required the browser to completely reload the web page on every request. This reloading of the page is referred to as a **page refresh**.

Blazor leverages AJAX and WASM as means to allow web pages to interact with the server in ways that don't require a complete page refresh. Instead, you could change a portion of the page's content and leave the rest of the page untouched. But the technologies of AJAX and WASM present two different ways of accomplishing this interactivity.

With AJAX, the "work" is performed on the web server and communication between the browser (*client*) and the server is performed through background "sockets". The browser makes this background request through a socket and the server processes the request and sends back a response to that same socket. This is known as **server-side** processing. The key thing here is that the web server is the one that performs the critical processing that generates new content for the browser. In Blazor, this AJAX communication is done using an open-source package called [SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-8.0).

WASM offers a different approach to processing or handling interactivity. With WASM, the processing code is located on the client's browser; this is known as **client-side** processing. What WASM brings to the table is the ability for your C# code to be "bundled" as a library that gets executed by the browser. Any communication of data with the server (if needed) would still be processed via sockets, but the critical executing logic is housed inside the browser itself, typically resulting in much faster response times.


### Blazor and .NET 8

**Blazor has changed** recently. In .NET 8, Blazor presents capabilities that allow us to integrate server-side (AJAX/SignalR) processing and client-side (WASM) processing in the same ASP.NET Core project. Prior to .NET 8, you as a developer would have to choose between separate project templates - client-side or server-side - in order to get the approach you wanted. It was an either/or kind of decision.

While the new Blazor template in .NET 8 unifies both approaches in the same project, it introduces additional complexity in the form of having to specify your intended **render mode**.

## Setup

From within this folder, I have run the following `dotnet` CLI commands to set up the project:

```ps
dotnet new sln -n SeveralSamples
dotnet new blazor -o Website -n WebApp -e
dotnet sln add Website/WebApp.csproj
```

Note that I am starting with an **empty** Blazor 8 template, to remove any distractions or assumptions around styling (ala *Bootstrap*) and to ensure that fundamental configuration items (e.g.: lines in the `Program.cs` and other files) are addressed. For details on the setup of these within this sample, see the following documents:

- [Styling Setup](./Docs/Styling.md)
- [`Program.cs` Setup](./Docs/ProgramConfiguration.md)

----

## References

> *In the early-to-mid 1990s, most Websites were based on complete HTML pages. Each user action required a complete new page to be loaded from the server. This process was inefficient, as reflected by the user experience: all page content disappeared, then the new page appeared. Each time the browser reloaded a page because of a partial change, all the content had to be re-sent, even though only some of the information had changed.*
>
> [source - Wikipedia](https://en.wikipedia.org/wiki/Ajax_(programming))

- [💯 ASP.NET Core updates in .NET 8 Preview 7 - Blazor - Antiforgery](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-7/#antiforgery-integration)
  - This article by Daniel Roth gives an easy-to-read explanation of concerns important to forms in Blazor 8
- [Auto-Focus and Input ...](https://www.meziantou.net/auto-focus-an-input-in-a-blazor-form.htm)