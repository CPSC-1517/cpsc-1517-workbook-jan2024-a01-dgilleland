# Giving User Feedback in Blazor Forms

## Approaches for Simple Feedback

Thanks to interactive SSR (`@render InteractiveServer`) in Blazor, giving the user feedback on any activity is pretty easy to do.

## Validation Feedback

*TBD*

## Long Running Tasks

Of course, there is also the potential for a **long-running** job on the server. In those cases, we should use a combination of `async` methods with `StateHasChanged()` notifications. I decided to ask Bing about it, and here is our conversation.

![Me](./Images/Copilot-Me.png)

In Blazor for .NET8, how would I indicate a long running process in a component after user input rather than just on initialization.

![AI](./Images/Copilot-AI.png)

Certainly! In **Blazor .NET 8**, you can indicate a long-running process in a component after user input. Let's explore how to achieve this:

1. **Component Initialization**:
   - When a component initializes, you can perform tasks in the `OnInitializedAsync` lifecycle method. This method is called once when the component is created.
   - For example, you can retrieve data from an API within `OnInitializedAsync`:
     ```csharp
     protected override async Task OnInitializedAsync()
     {
         result = await SomeApiCall(); // Retrieve data from API
     }
     ```

2. **User Input and Refresh**:
   - To handle user input (e.g., button click) and refresh the component, follow these steps:
     - Create a button or any other UI element that triggers the desired action.
     - In the button's `@onclick` event handler, call a method that updates the component state and triggers a refresh.
     - Use `StateHasChanged()` to notify Blazor that the component's state has changed and needs re-rendering.
     - Example:
       ```csharp
       private async Task ButtonClick()
       {
           result = null; // Clear existing data
           StateHasChanged(); // Trigger re-render
           await SomeApiCall(); // Retrieve updated data
       }
       ```

3. **Render Modes**:
   - In .NET 8, Blazor introduced a new render mode called `Auto`.
   - By adding `@rendermode Auto` to your component, you can improve startup time. It uses `@rendermode InteractiveServer` on initial page load and `@rendermode InteractiveClient` on subsequent loads ².

Remember to adjust the code snippets according to your specific use case. Happy coding! 🚀

Source: Conversation with Bing, 2024-03-03
(1) c# - Improve Performance of initial page load time with Blazor .... https://stackoverflow.com/questions/77590329/improve-performance-of-initial-page-load-time-with-blazor-webassembly.
(2) Blazor client side refresh component - Stack Overflow. https://stackoverflow.com/questions/62602820/blazor-client-side-refresh-component.
(3) ASP.NET Core Razor component lifecycle | Microsoft Learn. https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-8.0.
(4) .NET 8 Blazor component visibly loading twice? Check your prerendering. https://jonhilton.net/persist-state-between-renders-net8/.
(5) undefined. https://github.com/ovie91/RefreshComponent.

----

![Me](./Images/Copilot-Me.png)

How would I apply that to give the user a visual indication of some long-running server-side process?

![AI](./Images/Copilot-AI.png)

Certainly! To give the user a visual indication of a long-running server-side process in a Blazor component, you can use loading spinners or progress bars. These visual cues help users understand that something is happening in the background. Here's how you can achieve this:

1. **Loading Spinner**:
   - Display a loading spinner (such as a rotating icon) while the server-side process is ongoing.
   - You can use a CSS class or a Blazor component to create the spinner.
   - Example:
     ```razor
     @if (isLoading)
     {
         <div class="spinner"></div>
     }
     ```

2. **Progress Bar**:
   - Show a progress bar that fills up gradually as the process completes.
   - You can use the built-in `ProgressBar` component in Blazor.
   - Example:
     ```razor
     <ProgressBar Value="@progress" />
     ```

3. **State Management**:
   - Maintain a boolean flag (`isLoading`) to track whether the process is ongoing.
   - Update this flag when the process starts and completes.
   - Example:
     ```csharp
     private bool isLoading = false;

     private async Task StartLongRunningProcess()
     {
         isLoading = true;
         StateHasChanged(); // Trigger re-render
         await SomeLongRunningTask();
         isLoading = false;
         StateHasChanged(); // Update UI
     }
     ```

4. **User Interaction**:
   - Trigger the long-running process based on user input (e.g., button click).
   - Call the `StartLongRunningProcess` method when the user interacts with the UI.
   - Example:
     ```razor
     <button @onclick="StartLongRunningProcess">Start Process</button>
     ```

Remember to customize the loading spinner or progress bar according to your application's design. By incorporating these visual cues, you'll provide a better user experience during long-running operations. 🚀

----

![Me](./Images/Copilot-Me.png)

Is there a way to determine how far along we are in an `await` call, so that we can give semi-accurate information for a progress bar?

![AI](./Images/Copilot-AI.png)

Certainly! When dealing with asynchronous operations, it's challenging to provide precise progress information for a progress bar. However, I can offer some strategies to give users a rough estimate:

1. **Chunked Processing**:
   - If your long-running process involves iterating over a large dataset or performing multiple steps, consider breaking it into smaller chunks.
   - After processing each chunk, update the progress bar. For example, if you're processing 100 items, update the progress after every 10 items.

2. **Estimation Based on Steps**:
   - Divide your process into logical steps or stages.
   - Estimate the total number of steps required for completion.
   - As each step completes, increment the progress bar by a fixed percentage (e.g., 10% per step).

3. **Time-Based Estimation**:
   - If you have an idea of how long the entire process might take, you can use time-based estimation.
   - Record the start time when the process begins.
   - Periodically check the elapsed time and estimate progress based on the time elapsed.

4. **Cancellation Tokens and Progress Reporting**:
   - When using `await`, consider using `CancellationToken` and `IProgress<T>` to report progress.
   - Pass a `CancellationToken` to your asynchronous method. You can cancel the operation if needed.
   - Use `IProgress<T>` to report progress updates. For example:
     ```csharp
     async Task MyLongRunningTask(IProgress<int> progress, CancellationToken cancellationToken)
     {
         for (int i = 0; i < 100; i++)
         {
             // Do some work...
             await Task.Delay(100); // Simulate work
             progress.Report(i); // Report progress
             cancellationToken.ThrowIfCancellationRequested();
         }
     }
     ```

Remember that these approaches provide only rough estimates. The actual progress may vary due to factors like network latency, varying task durations, and system load. Users appreciate any feedback during long processes, even if it's not perfectly accurate! 🚀

