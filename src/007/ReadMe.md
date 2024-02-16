# Blazor 8 - Empty Template

In this lesson we will explore the use of the empty template option when creating Blazor 8 web applications.

----

## Comparing Blazor 8 Templates

The default Blazor template comes with some sample code to help newcomers learn about basic aspects of a Blazor-based web application. Seasoned developers may choose to start with the *empty template* (the `-e` option) so that they can have more control over what is (and *isn't*) in their project.

The following table shows the commands to run to get a listing of what files are created for the default and the empty Blazor 8 templates.

| Blazor 8 | Blazor 8 Empty |
|---|---|
| `dotnet new blazor --dry-run -n WebApp -o Blazor` | `dotnet new blazor --dry-run -n WebApp -o Blazor -e` |

### 'Bout Bootstrap

The default template uses Bootstrap for its layout and styling. While great in its day, Bootstrap is now considered as a "heavy" legacy layout approach. Modern designers use CSS Grid for layout along with other CSS advances to produce stunning and flexible layouts while maintaining a "semantic" approach to their HTML (see [here](https://web.dev/learn/html/semantic-html/) and [here](https://www.semrush.com/blog/semantic-html5-guide/) for a good introduction to semantic HTML).

## Starting With a Clean Slate

Run the following in the terminal to start up a solution with a Blazor 8 website using the empty template.

- [ ] Create a Blazor 8 web application (empty template - notice the `-e`)

    ```powershell
    # Run from the root of your workbook
    dotnet new blazor -o src/007/Website -n WebApp -e
    dotnet new sln -o src/007 -n EmptyBlazorDemo
    cd src/007
    dotnet sln add Website/WebApp.csproj
    cd Website
    ```

- [ ] Run the blazor website (in watch mode)

    ```powershell
    dotnet watch
    ```

When you view your website, the first thing you should notice is that its appearance is very, very "plain". This empty template makes no real assumptions about how the site should be styled.

### No-Class (*Classless*) Styling

**"No-class"** styling brings the benefit of allowing your HTML to be "clean" and focused on the *content* of your website/application. They say "Content is King", but that's only lip-service if you wind up butchering your HTML with CSS classes and nesting `<div>`s just to get it to "look good".

> For a nice overview of various no-class stylesheets, take a look at the Sep '23 article [**"Comparing classless CSS frameworks"**](https://blog.logrocket.com/comparing-classless-css-frameworks/) by Shalitha Suranga. An older list that includes other classless frameworks can be seen in the article ["No-Class CSS Frameworks"](https://css-tricks.com/no-class-css-frameworks/) (May, 2020).

#### [Pico CSS](https://picocss.com/)

Add the following line to the `<head>` of the **`App.razor`** component. ***NOTE:** the portions that read `@@picocss` and `pico@@2` each have an extra `@` because of how Razor pages (the foundation for Blazor) use that as a way of identifying variables; the double `@@` "escapes" so that a single `@` symbol will appear in the rendered HTML.*

```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@@picocss/pico@@2/css/pico.min.css">
``` 

Alternatively, use the following for the fluid viewport of [classless Pico CSS](https://picocss.com/docs/classless.html).

```html
// Fluid viewport
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@picocss/pico@@2/css/pico.fluid.classless.min.css">
```

#### Give Your Site Some Structure

The whole purpose of the **`MainLayout.razor`** component is to add some layout and structure to your website. Its content is primarily meant to represent a "shell" of HTML that makes up the `<body>` element. The `@Body` variable references the page-specific content that is injected into the overall page as it is rendered by the web server. Make changes to your `MainLayout.razor` so that it matches the following. Observe the effect of these changes in the appearance of your site.

```razor
@inherits LayoutComponentBase

<nav class="container-fluid">
    <ul>
        <li><img alt="logo" src="/icons8-internet-laces-72.png" /></li>
        <li><strong>Blazor 8</strong></li>
    </ul>
    <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/weather">Weather</a></li>
        <li><a href="#" role="button">Button</a></li>
    </ul>
</nav>
<main class="container">
    @Body
</main>
<footer class="container" data-theme="dark">
    <hr />
    <ul>
        <li>Based on the Blazor 8 (Empty) template.</li>
        <li>Using the <a href="https://picocss.com/" target="_blank">PicoCSS</a> No-Class Stylesheet.</li>
        <li><a target="_blank" href="https://icons8.com/icon/eTJ3Q9REJ1nH/internet">Internet</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>.</li>          
    </ul>
    <p>&copy; 2024 - Instructor Dan</p>
</footer>

<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

### Bring Back the Weather

Add another file in your `Pages` folder of components, and name it `Weather.razor`. Include the following as the content for that page.

```razor
@page "/weather"
@attribute [StreamRendering]

<PageTitle>Weather</PageTitle>

<h1>Weather</h1>

<p>This component demonstrates showing data.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table>
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();
    }

    private class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
```

### Try Another Stylesheet

In your `App.razor` component, replace the Pico CSS reference with the following and observe how the style of your site has been changed without any re-arrangement of your existing HTML.

```html
<link rel="stylesheet" href="https://unpkg.com/mvp.css"> 
```

----

## A Little Bit of Bling

### Adding a FavIcon

Put your desired favicon in the `wwwroot` folder, and add the following to the `<head>` of your `App.razor` file. You may have to adjust the `type` and `href` portions to match the kind of image you are using as your favicon (the sample below uses a png file: ![favicon](./_move_to_wwwroot/icons8-internet-laces-16.png)).

```html
<link rel="icon" type="image/png" href="/favicon.png">
```

### ~~Font~~*Line*Awesome

If you've heard of Font-Awesome, then you need to take a look at [**Line-Awesome**](https://icons8.com/line-awesome).

Add the following to the `<head>` element of your Blazor application.

```html
<link rel= "stylesheet"
      href= "https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css" >
```

Then, change your `<nav>` links to include icons in the link, as follows:

```html
<ul>
    <li><a href="/"><i class="las la-home"></i> Home</a></li>
    <li><a href="/weather"><i class="las la-wind"></i> Weather</a></li>
    <li><a href="#" role="button"><i class="las la-sitemap"></i> Button</a></li>
</ul>
```

----

### Credits

- **FavIcon:** - ![](./_move_to_wwwroot/icons8-internet-laces-16.png) [Internet](https://icons8.com/icon/eTJ3Q9REJ1nH/internet) icon by [Icons8](https://icons8.com)
