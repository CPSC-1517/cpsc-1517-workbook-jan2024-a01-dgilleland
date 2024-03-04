# Modal Survey Component

> I wanted to create a fun modal survey component as a demonstration, so I asked Microsoft Copilot to help. It took a few tries. Here's my various conversations.
>
> - [First Attempt](#first-attempt)
> - [Second Attempt](#second-attempt)


## First Attempt

![Me](./Images/Copilot-Me.png)

I want you to create a .NET 8 Blazor custom component in C# that will open up a modal dialog with a feedback survey of one to five different questions of the form "On a scale of 1 to 10, how likely are you to...". The user should be allowed to mouse over or click on a series of star icons to enter their response to each question. The questions should be given to the component by the parent as an array of strings along with another parameter for the question prefix (with the string `"On a scale of 1 to 10, how likely are you to"` as its default value).

![AI](./Images/Copilot-AI.png)

Sure, I can help you with that. Here's a basic implementation of a Blazor component that should meet your requirements:

```csharp
@using Microsoft.AspNetCore.Components

<Modal @ref="Modal">
    <div class="modal-content">
        <div class="modal-header">
            <h2 class="modal-title">Feedback Survey</h2>
        </div>
        <div class="modal-body">
            @for (int i = 0; i < Questions.Length; i++)
            {
                <div class="question">
                    <p>@QuestionPrefix @Questions[i]</p>
                    <StarRating @bind-Value="ratings[i]" />
                </div>
            }
        </div>
        <div class="modal-footer">
            <button class="btn btn-primary" @onclick="Submit">Submit</button>
        </div>
    </div>
</Modal>

@code {
    [Parameter] public string[] Questions { get; set; }
    [Parameter] public string QuestionPrefix { get; set; } = "On a scale of 1 to 10, how likely are you to";
    private int[] ratings;
    private Modal Modal;

    protected override void OnParametersSet()
    {
        ratings = new int[Questions.Length];
    }

    private void Submit()
    {
        // Handle submission of ratings
        Modal.Hide();
    }
}
```

This code assumes the existence of a `Modal` component and a `StarRating` component. The `StarRating` component should allow the user to click on a series of star icons to enter their response, and it should support two-way data binding with its `Value` parameter.

Please note that this is a basic implementation and might need adjustments based on your specific requirements and existing codebase. For example, you might want to add validation to ensure that a rating has been provided for each question before the survey can be submitted. Also, you'll need to implement the `Submit` method to handle the submission of the ratings. This could involve sending the data to a server, storing it in a database, etc. depending on your application's needs.

----


![Me](./Images/Copilot-Me.png)

Now, generate the Modal component.

![AI](./Images/Copilot-AI.png)

Sure, here's a basic implementation of a `Modal` component in Blazor:

```csharp
@using Microsoft.AspNetCore.Components

<div class="modal @DisplayClass" tabindex="-1" style="display: @Display;">
    <div class="modal-dialog">
        @ChildContent
    </div>
</div>

@code {
    private string DisplayClass => IsOpen ? "show" : "";
    private string Display => IsOpen ? "block" : "none";

    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public bool IsOpen { get; set; }

    public void Show()
    {
        IsOpen = true;
        StateHasChanged();
    }

    public void Hide()
    {
        IsOpen = false;
        StateHasChanged();
    }
}
```

This `Modal` component uses Bootstrap classes for styling, so you'll need to have Bootstrap included in your project for it to display correctly. The `Show` and `Hide` methods can be used to open and close the modal, and the `IsOpen` parameter can be used to control the modal's visibility from a parent component.

Please note that this is a basic implementation and might need adjustments based on your specific requirements and existing codebase. For example, you might want to add animations for opening and closing the modal, or additional options for customizing the modal's appearance. Also, you'll need to ensure that the modal is appropriately accessible according to the Web Content Accessibility Guidelines (WCAG).

----


![Me](./Images/Copilot-Me.png)

Create the animations and event handlers for the `Modal` component that will allow the user to mouse over or click on a series of star icons (as Line-Awesome font icons) to enter their response to each question. The questions should be given to the component by the parent as an array of strings along with another parameter for the question prefix (with the string `"On a scale of 1 to 10, how likely are you to"` as its default value).

![AI](./Images/Copilot-AI.png)

Sure, I can help you with that. Here's a basic implementation of a `StarRating` component in Blazor that should meet your requirements:

```csharp
@using Microsoft.AspNetCore.Components

<div class="star-rating">
    @for (int i = 1; i <= 10; i++)
    {
        <span class="star @GetStarClass(i)" @onclick="() => SetRating(i)" @onmouseover="() => SetHover(i)" @onmouseout="() => SetHover(0)"></span>
    }
</div>

@code {
    [Parameter] public int Value { get; set; }
    [Parameter] public EventCallback<int> ValueChanged { get; set; }
    private int hover;

    private string GetStarClass(int star)
    {
        return (star <= (hover > 0 ? hover : Value)) ? "las la-star" : "lar la-star";
    }

    private void SetRating(int rating)
    {
        if (Value == rating)
        {
            Value = 0;
        }
        else
        {
            Value = rating;
        }
        ValueChanged.InvokeAsync(Value);
    }

    private void SetHover(int star)
    {
        hover = star;
    }
}
```

This `StarRating` component uses Line-Awesome font icons for the stars, so you'll need to have Line-Awesome included in your project for it to display correctly. The `Value` parameter represents the current rating, and it supports two-way data binding. The stars will be filled in up to the current rating, or up to the star being hovered over if the user is currently mousing over the component.

Please note that this is a basic implementation and might need adjustments based on your specific requirements and existing codebase. For example, you might want to add animations for the stars filling in and emptying, or additional options for customizing the appearance of the stars. Also, you'll need to ensure that the component is appropriately accessible according to the Web Content Accessibility Guidelines (WCAG).

----

## Second Attempt

![Me](./Images/Copilot-Me.png)

I want to use Blazor .NET8 to create a custom component called `ModalSurvey.razor` that has a `<dialog>` element that I can open as a model. I have a series of questions that I want you to help me with as I think through this problem. Here are my questions.

1. One idea I have is to allow the parent to control whether or not the `<ModalSurvey />` is rendered by wrapping it in a simple `@if(...){}` block. In that case, when the `<ModelSurvey />` gets rendered, then I would need either some Blazor code or some JavaScript to show the `<dialog>` element as a modal dialog. I would prefer to show/hide the `<dialog>` using C# in Blazor rather than using JavaScript. Is this possible, and if so, how could I accomplish this?
2. Another idea is to have the `<ModalSurvey />` respond to an event from the parent/containing component. In this case, the parent would trigger the `ModalSurvey.razor`'s event and code would run to toggle the dialog on/off. How might I accomplish this scenario?
3.  An alternate idea to the last one is for the `ModalSurvey.razor` to simply expose a public method that the parent can invoke to perform the toggling of the dialog. What would I need to do to make this scenario happen?

For each of these three questions/scenarios, create simple code samples for both the `ModalSurvey.razor` component and the page that will contain the component. Review your response for accuracy and correctness.

![AI](./Images/Copilot-AI.png)

Sure, I can help with that. Here are some code samples for each of your scenarios:

1. **Using an `@if` block to control rendering**

In your parent component, you can use a boolean variable to control the rendering of the `ModalSurvey` component. When the `ModalSurvey` component is rendered, you can use the `@ref` directive to create a reference to the component, and then call a method on the component to open the dialog.

Here's a simple example:

```csharp
@page "/parent"
@using YourNamespace.Components
@{
    bool showModal = false;
    ModalSurvey modalSurvey;
}

<button @onclick="() => showModal = true">Open Modal</button>

@if (showModal)
{
    <ModalSurvey @ref="modalSurvey" />
}

@code {
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && showModal)
        {
            modalSurvey.OpenDialog();
        }
    }
}
```

And in your `ModalSurvey.razor`:

```csharp
@code {
    public void OpenDialog()
    {
        // Code to open the dialog
    }
}
```

2. **Responding to an event from the parent component**

You can define an event callback in your `ModalSurvey` component, and then trigger this event from your parent component.

Here's how you might do this:

In your `ModalSurvey.razor`:

```csharp
@code {
    [Parameter]
    public EventCallback OnOpen { get; set; }

    protected override void OnParametersSet()
    {
        if (OnOpen.HasDelegate)
        {
            OnOpen.InvokeAsync(null);
        }
    }
}
```

And in your parent component:

```csharp
@page "/parent"
@using YourNamespace.Components

<ModalSurvey OnOpen="OpenDialog" />

@code {
    private void OpenDialog()
    {
        // Code to open the dialog
    }
}
```

3. **Exposing a public method for the parent to invoke**

You can define a public method in your `ModalSurvey` component, and then call this method from your parent component using a reference to the `ModalSurvey` component.

Here's an example:

In your `ModalSurvey.razor`:

```csharp
@code {
    public void ToggleDialog()
    {
        // Code to toggle the dialog
    }
}
```

And in your parent component:

```csharp
@page "/parent"
@using YourNamespace.Components
@{
    ModalSurvey modalSurvey;
}

<button @onclick="() => modalSurvey.ToggleDialog()">Toggle Modal</button>

<ModalSurvey @ref="modalSurvey" />
```

I hope this helps! Let me know if you have any other questions.

----


![Me](./Images/Copilot-Me.png)

Now, specifically to the question of the internal behaviour of my `ModalSurvey.razor` component: Imagine I have a `<dialog>Some content</dialog>` element that I want to interact with. Since it is a naitive HTML element with the capacity to render as a modal via a simple call to `.show()` or `.showModal()` in JavaScript, is there a way to trigger that in C# with either no or very minimal JavaScript? I would like to either eliminate or at the very least minimize my reliance on JavaScript interop. Give me alternate scnearios with some accurate and simple example code, along with an analysis of what I need to consider when choosing between the scenarios.

![AI](./Images/Copilot-AI.png)

Blazor provides a way to interact with JavaScript from C# through JavaScript Interop, but it doesn't provide a way to directly interact with HTML elements from C#. However, you can minimize the JavaScript code by creating a small JavaScript function that you call from your Blazor code.

Here are two scenarios:

1. **Using minimal JavaScript with JSInterop**

You can create a small JavaScript function that opens a dialog, and then call this function from your Blazor code using JSInterop. Here's an example:

In your `wwwroot/index.html` file, add the following script:

```javascript
window.openDialog = function(id) {
    var dialog = document.getElementById(id);
    dialog.showModal();
}
```

And in your `ModalSurvey.razor`:

```csharp
@inject IJSRuntime JSRuntime

<dialog id="myDialog">Some content</dialog>
<button @onclick="OpenDialog">Open Dialog</button>

@code {
    private async Task OpenDialog()
    {
        await JSRuntime.InvokeVoidAsync("openDialog", "myDialog");
    }
}
```

2. **Using Blazor's ElementReference**

Another option is to use Blazor's `ElementReference` to get a reference to the dialog element, and then use JSInterop to call the `showModal` method on this element. Here's an example:

In your `ModalSurvey.razor`:

```csharp
@inject IJSRuntime JSRuntime

<dialog @ref="dialogRef">Some content</dialog>
<button @onclick="OpenDialog">Open Dialog</button>

@code {
    private ElementReference dialogRef;

    private async Task OpenDialog()
    {
        await JSRuntime.InvokeVoidAsync("openDialog", dialogRef);
    }
}
```

And in your `wwwroot/index.html` file, modify the script to accept an `ElementReference`:

```javascript
window.openDialog = function(dialog) {
    dialog.showModal();
}
```

In both scenarios, you're still using JavaScript, but the amount of JavaScript code is minimal. The choice between these scenarios depends on your specific requirements and preferences. If you prefer to keep all your JavaScript code in one place, the first scenario might be better. If you prefer to handle as much as possible in your Blazor code, the second scenario might be more suitable. In both cases, the JavaScript code is minimal and serves only to bridge the gap between Blazor and native HTML functionality.

----

![Me](./Images/Copilot-Me.png)

Tell me more about Blazor's `ElementReference` type. What is it intended for, and how is it supposed to be used? Does the use of `ElementReference` still require the `@inject IJSRuntime JSRuntime`?

![AI](./Images/Copilot-AI.png)

In Blazor, the `ElementReference` structure represents a reference to a DOM element. It's intended to be used when you need to interact with a specific element in your Razor component.

Here's how you might use it:

```csharp
<button @ref="myButton">Click me</button>

@code {
    ElementReference myButton;
}
```

In this example, `myButton` is an `ElementReference` that refers to the button element. You can use this reference in your C# code to interact with the button.

However, `ElementReference` by itself doesn't provide a way to interact with the DOM. To call a method on a DOM element or to read/write its properties, you still need to use JavaScript Interop, and that's where `IJSRuntime` comes in.

Here's an example of how you might use `IJSRuntime` with `ElementReference`:

```csharp
@inject IJSRuntime JSRuntime
<button @ref="myButton">Click me</button>

@code {
    ElementReference myButton;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("focusElement", myButton);
        }
    }
}
```

In this example, after the component is first rendered, it uses `IJSRuntime` to call a JavaScript function named `focusElement`, passing the `ElementReference` as an argument. The `focusElement` function, which you would define in a JavaScript file, might look like this:

```javascript
function focusElement(element) {
    element.focus();
}
```

This function receives a DOM element as an argument and calls its `focus` method. In this way, you can use `ElementReference` and `IJSRuntime` together to interact with DOM elements from your Blazor code. However, the goal is to minimize the reliance on JavaScript and keep as much logic as possible in C#. The use of `ElementReference` and `IJSRuntime` is a bridge to enable interactions that are not natively supported by Blazor. As Blazor continues to evolve, we can expect more and more of these interactions to be supported directly in C#..

Source: Conversation with Bing, 2024-03-03
(1) en.wikipedia.org. https://en.wikipedia.org/wiki/Blazor.

----

![Me](./Images/Copilot-Me.png)

Am I able to get the `IJSRuntime` with that simple `@inject` line in my component, or do I need some other configuration elsewhere, such as in my `Program.cs` in order to make JavaScript Interop available?

![AI](./Images/Copilot-AI.png)

Yes, you can get the `IJSRuntime` instance in your Blazor component with the `@inject` directive. This is because `IJSRuntime` is a service that's registered with the dependency injection (DI) system by default when you create a new Blazor application.

Here's how it works:

- When your Blazor app starts, it configures a DI container with services that are available for injection.
- `IJSRuntime` is one of these services. It's the service that provides the JavaScript Interop functionality.
- When you use the `@inject` directive in a component, Blazor resolves the service from the DI container and makes it available in your component.

So, you don't need to do anything special in your `Program.cs` or anywhere else to make `IJSRuntime` available for injection. As long as you're running a Blazor application, `IJSRuntime` is available for you to use.

Here's an example of how you might inject `IJSRuntime` into a component:

```csharp
@page "/example"
@inject IJSRuntime JSRuntime

<!-- Your component markup goes here -->

@code {
    // Your component code goes here
}
```

In this example, `JSRuntime` is a property in your component that holds a reference to the `IJSRuntime` instance. You can use this property to call JavaScript functions from your component code. For example, you might use `JSRuntime.InvokeVoidAsync("console.log", "Hello, world!")` to write a message to the browser's console. 

Remember, though, that while JavaScript Interop is a powerful feature, it's generally recommended to use it sparingly. Blazor is designed to let you write client-side web UI using .NET, so in most cases, you should be able to do what you need to do without resorting to JavaScript. If you find yourself often reaching for `IJSRuntime`, it might be a sign that you're fighting against the grain of the framework. In those cases, consider looking for a more "Blazor-ish" way to accomplish your goal. But for those cases where you do need to use JavaScript, `IJSRuntime` is there for you.

----

![Me](./Images/Copilot-Me.png)

You state that the `IJSRuntime` is a service that is registered with the dependency injection system by default. I created my Blazor project from the `dotnet` CLI using the new `blazor` template .NET 8 and I specified the `-e` flag to create a minimal setup (because I am avoiding Bootstrap styling). Is that JavaScript Interop included by default in that project template as well?

![AI](./Images/Copilot-AI.png)

Yes, even in the minimal setup created with the `-e` flag, the `IJSRuntime` service is included by default. The `IJSRuntime` service is a fundamental part of Blazor, as it provides the bridge between .NET and JavaScript, which is essential for many features of Blazor.

Even though the minimal template reduces the amount of boilerplate and pre-included libraries (like Bootstrap), it doesn't remove core services like `IJSRuntime`. So, you can still use JavaScript Interop in your Blazor application created with the minimal template.

Here's how you can use it in your component:

```csharp
@page "/example"
@inject IJSRuntime JSRuntime

<!-- Your component markup goes here -->

@code {
    // Your component code goes here
}
```

In this example, `JSRuntime` is a property in your component that holds a reference to the `IJSRuntime` instance. You can use this property to call JavaScript functions from your component code. For example, you might use `JSRuntime.InvokeVoidAsync("console.log", "Hello, world!")` to write a message to the browser's console. 

Remember, though, that while JavaScript Interop is a powerful feature, it's generally recommended to use it sparingly. Blazor is designed to let you write client-side web UI using .NET, so in most cases, you should be able to do what you need to do without resorting to JavaScript. If you find yourself often reaching for `IJSRuntime`, it might be a sign that you're fighting against the grain of the framework. In those cases, consider looking for a more "Blazor-ish" way to accomplish your goal. But for those cases where you do need to use JavaScript, `IJSRuntime` is there for you.

----

![Me](./Images/Copilot-Me.png)

> *A follow-up prompt suggested by Copilot:*

What are some best practices for using JavaScript Interop in Blazor?

![AI](./Images/Copilot-AI.png)

Sure, here are some best practices for using JavaScript Interop in Blazor:

1. **Minimize JavaScript Interop**: While JavaScript Interop is a powerful feature, it's generally recommended to use it sparingly. Blazor is designed to let you write client-side web UI using .NET, so in most cases, you should be able to do what you need to do without resorting to JavaScript.

2. **Avoid Synchronous Calls**: Always use asynchronous calls when invoking JavaScript functions from Blazor. Synchronous calls can block the thread and lead to performance issues.

3. **Use `IJSRuntime` Carefully**: The `IJSRuntime` service provides the JavaScript Interop functionality. It's a powerful tool, but it should be used carefully. Avoid calling `IJSRuntime.InvokeVoidAsync` or `IJSRuntime.InvokeAsync` in a loop, as this can cause performance issues.

4. **Dispose of DotNetObjectReferences**: If you're passing .NET objects to JavaScript via `DotNetObjectReference.Create`, make sure to dispose of them when they're no longer needed to prevent memory leaks.

5. **Keep JavaScript Functions Small**: When writing JavaScript functions to be called from Blazor, try to keep them small and focused. This makes the code easier to maintain and debug.

6. **Error Handling**: Make sure to handle errors in your JavaScript code. Unhandled JavaScript exceptions can cause your Blazor app to fail.

7. **Encapsulate JavaScript Code**: Consider encapsulating your JavaScript code in JavaScript modules. This keeps your JavaScript code organized and makes it easier to manage.

8. **Use Blazor Libraries**: Before writing custom JavaScript code, check if there's a Blazor library that does what you need. The Blazor ecosystem is growing rapidly, and there are libraries available for many common tasks.

Remember, the goal of Blazor is to write client-side web UI in .NET. JavaScript Interop is a bridge to enable interactions that are not natively supported by Blazor. As Blazor continues to evolve, we can expect more and more of these interactions to be supported directly in C#.

----


![Me](./Images/Copilot-Me.png)

> *A follow-up prompt suggested by Copilot:*

How do I use JavaScript libraries with Blazor?

![AI](./Images/Copilot-AI.png)

Using JavaScript libraries with Blazor involves a few steps:

1. **Include the JavaScript library in your project**: You can do this by downloading the library and placing it in your project directory, or by using a package manager like npm³.

2. **Reference the library in your HTML file**: You can add a `<script>` tag to your `_Host.cshtml` (for server-side Blazor) or `index.html` (for client-side Blazor) file². The script tag should point to the JavaScript file in your `wwwroot` folder.

3. **Use JavaScript Interop to call functions in the library**: You can use the `IJSRuntime` service in Blazor to call JavaScript functions from your .NET code¹. 

Here's an example of how you might use a JavaScript function in a Blazor component:

```csharp
@inject IJSRuntime JSRuntime

@code {
    protected override async Task OnInitializedAsync()
    {
        await JSRuntime.InvokeVoidAsync("yourFunction");
    }
}
```

In this example, `yourFunction` is a function in your JavaScript library. You're using `IJSRuntime` to call this function when the Blazor component is initialized.

4. **Create a JavaScript file that contains functions you want to use in your Blazor component**: This file should reference the library and contain JavaScript functions that you want to use in your Blazor component³.

5. **Use `IJSRuntime` to call these functions from your Blazor code**¹.

Remember, while JavaScript Interop is a powerful feature, it's generally recommended to use it sparingly. Blazor is designed to let you write client-side web UI using .NET, so in most cases, you should be able to do what you need to do without resorting to JavaScript¹.

Source: Conversation with Bing, 2024-03-03
(1) How can I use existing JavaScript libraries with Blazor? - Syncfusion. https://www.syncfusion.com/faq/how-can-i-use-existing-javascript-libraries-with-blazor.
(2) How to load JavaScript libraries using a Blazor server-side application .... https://stackoverflow.com/questions/62617509/how-to-load-javascript-libraries-using-a-blazor-server-side-application.
(3) ASP.NET Core Blazor JavaScript interoperability (JS interop). https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-8.0.
(4) Wrapping JavaScript libraries in Blazor WebAssembly/WASM - elmah.io. https://blog.elmah.io/wrapping-javascript-libraries-in-blazor-webassembly-wasm/.
(5) undefined. https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i.

----


![Me](./Images/Copilot-Me.png)

I am interested in using pnpm to add external JavaScript libraries to my Blazor project. I know that this puts me in a scenario of having a "hybrid" setup - one where my `.csproj` identifies the Blazor project and one where a `package.json` identifies the Node libraries I'm including.

Explain how to set this up and what considerations I need to make when using Node packages in a Blazor .NET 8 project.

![AI](./Images/Copilot-AI.png)

Sure, here's a step-by-step guide on how to set up a Blazor project with pnpm and considerations when using Node packages:

1. **Create your Blazor project**: You can create a new Blazor project using the `dotnet` CLI or Visual Studio¹.

2. **Initialize pnpm**: Navigate to your project directory in the terminal and run `pnpm init` to create a `package.json` file. This file will keep track of your Node.js dependencies.

3. **Install Node packages**: Use the `pnpm install <package-name>` command to install the JavaScript libraries you need. These libraries will be added to the `node_modules` directory and listed as dependencies in your `package.json` file.

4. **Reference the library in your HTML file**: Add a `<script>` tag to your `_Host.cshtml` (for server-side Blazor) or `index.html` (for client-side Blazor) file². The script tag should point to the JavaScript file in your `wwwroot` folder.

5. **Use JavaScript Interop to call functions in the library**: You can use the `IJSRuntime` service in Blazor to call JavaScript functions from your .NET code¹.

Here are some considerations when using Node packages in a Blazor .NET 8 project:

- **Compatibility**: Not all Node.js packages will work with Blazor, as Blazor runs on WebAssembly in the browser, while Node.js packages are designed to run in a Node.js environment on the server. Make sure the packages you choose are compatible with the browser environment.

- **Size**: JavaScript libraries add to the size of your application, which can affect load times. Be mindful of the size of the libraries you're adding.

- **Maintenance**: Using JavaScript libraries means you'll have to keep them up-to-date and ensure they remain compatible with your Blazor app as it evolves.

- **JavaScript Interop**: While powerful, JavaScript Interop should be used sparingly. It's generally recommended to use it only when necessary and to prefer .NET implementations where possible¹.

Remember, the goal of Blazor is to write client-side web UI in .NET. JavaScript Interop is a bridge to enable interactions that are not natively supported by Blazor. As Blazor continues to evolve, we can expect more and more of these interactions to be supported directly in C#.

Source: Conversation with Bing, 2024-03-03
(1) Build and deploy .NET 8 Blazor WASM apps with serverless APIs using .... https://techcommunity.microsoft.com/t5/apps-on-azure-blog/build-and-deploy-net-8-blazor-wasm-apps-with-serverless-apis/ba-p/3988412.
(2) Blazor in .NET 8: Full stack Web UI | Chris Sainty - Building with Blazor. https://chrissainty.com/blazor-in-dotnet-8-full-stack-web-ui/.
(3) How to Use NPM Packages in Blazor - Brian Lagunas - Git Piper. https://gitpiper.com/resources/blazor/articles/using-npm-packages-in-blazor-october.
(4) Blazor: How to include npm dependencies into a Razor Class Library?. https://stackoverflow.com/questions/59355881/blazor-how-to-include-npm-dependencies-into-a-razor-class-library.

----


![Me](./Images/Copilot-Me.png)



![AI](./Images/Copilot-AI.png)



----


![Me](./Images/Copilot-Me.png)



![AI](./Images/Copilot-AI.png)



----

## Appendix

> Verified responses are indicated with a :100: emoji - `:100:`.
>
> For additional emojis, check out [Emojis Wiki](https://emojis.wiki/). For symbols that can be copied, check out [Symbol Copy](https://www.symbolcopy.com/)

