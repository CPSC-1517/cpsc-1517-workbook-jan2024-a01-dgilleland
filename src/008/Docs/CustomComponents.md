# Custom Blazor Components

> In Blazor, you have the ability to create custom components as reusable items for rendering information. This can be particularly handy when you have complex types whose content/details you intend to render.
>
> I am already comfortable with the notion of passing simple primitives through attributes/properties of custom components, but I was uncertain of how Blazor would handle attributes/properties that are complex (e.g.: classes), so I started a chat with Bing's Copilot.


![Me](./Images/Copilot-Me.png)

In blazor .net8, can i pass an object as a component parameter?

![AI](./Images/Copilot-AI.png)

Certainly! In **Blazor .NET 8**, you can indeed pass an object as a component parameter. Let me guide you through a couple of approaches:

1. **Templated Components**:
    - Templated components allow you to create reusable components that can internally use other child components. You can pass child components as parameters.
    - Here's an example of a `TextBox` component that accepts a custom label component as a parameter:
        ```razor
        @typeparam inputType

        <div class="textbox">
            @if (LabelTemplate != null && TItem != null)
                @LabelTemplate(TItem)
            <input type="text" />
        </div>

        @code {
            [Parameter] public RenderFragment<inputType> LabelTemplate { get; set; }
            [Parameter] public inputType TItem { get; set; }
        }
        ```
    - In this example, `LabelTemplate` is a parameter that accepts a component (of type `inputType`) to render the label. You can use it like this:
        ```razor
        <Textbox TItem="myPerson">
            <LabelTemplate>
                @context.Name
            </LabelTemplate>
        </Textbox>
        ```
    - Here, `myPerson` is an instance of a `Person` object, and the label will display the person's name.

2. **Dynamic Components**:
    - If dynamically-rendered components have parameters, you can pass them into the `DynamicComponent` as an `IDictionary<string, object>`. The string represents the parameter name, and the object is the parameter's value ².

Remember that these approaches allow you to pass objects as parameters, making your components more flexible and reusable. Happy coding! 🚀

Source: Conversation with Bing, 2024-03-03

(1) Dynamically-rendered ASP.NET Core Razor components. https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamiccomponent?view=aspnetcore-8.0.

(2) Pass a child component as Parameter in Blazor - Stack Overflow. https://stackoverflow.com/questions/58670470/pass-a-child-component-as-parameter-in-blazor.

(3) Pass root component parameters in ASP.NET Core Blazor Hybrid. https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/root-component-parameters?view=aspnetcore-8.0.

(4) ASP.NET Core Blazor attribute splatting and arbitrary parameters. https://learn.microsoft.com/en-us/aspnet/core/blazor/components/splat-attributes-and-arbitrary-parameters?view=aspnetcore-8.0.

(5) How Can I Pass an Object Property to a Razor Component as a Parameter. https://stackoverflow.com/questions/65377594/how-can-i-pass-an-object-property-to-a-razor-component-as-a-parameter.

----

![Me](./Images/Copilot-Me.png)

That's not quite what I was asking about. Imagine I have a class called `Starship` and I want to create a component called `StarshipProfile.razor` with a property of `[Parameter] public Starship Ship { get; set; }`. My intent is to pass in a Starship object as the Ship information, but `Starship` is not a primitive type; it is a class. How would I then refer to the `Ship` parameter when I try to use  `<StarshipProfile />` in another page?

![AI](./Images/Copilot-AI.png)

I apologize for the misunderstanding. Thank you for clarifying your question!

When you create a component called `StarshipProfile.razor` with a property of `[Parameter] public Starship Ship { get; set; }`, you can indeed pass an instance of the `Starship` class as the `Ship` information. Here's how you would refer to the `Ship` parameter when using `<StarshipProfile />` in another page:

1. **Creating the `StarshipProfile` Component**:
    - First, create your `StarshipProfile.razor` component with the `Ship` parameter:
        ```razor
        @inherits ComponentBase

        <div>
            <h3>Starship Profile</h3>
            <p>Ship Name: @Ship.Name</p>
            <!-- Other ship details here -->
        </div>

        @code {
            [Parameter] public Starship Ship { get; set; }
        }
        ```
    - In this example, I assume that the `Starship` class has a property called `Name`. You can replace `@Ship.Name` with other properties from your `Starship` class.

2. **Using the `StarshipProfile` Component**:
    - In another page (e.g., `Index.razor`), you can use the `StarshipProfile` component and pass an instance of `Starship` as the `Ship` parameter:
        ```razor
        @page "/"

        <h1>Starship Information</h1>
        <!-- Create an instance of Starship (you can fetch this from your data source) -->
        @code {
            private Starship myStarship = new Starship
            {
                Name = "USS Enterprise",
                // Other properties...
            };
        }

        <StarshipProfile Ship="myStarship" />
        ```
    - In this example, `myStarship` is an instance of the `Starship` class. You pass it to the `Ship` parameter of the `StarshipProfile` component.

3. **Accessing Properties Within `StarshipProfile`**:
    - Inside the `StarshipProfile` component, you can access the properties of the `Ship` object directly using `@Ship.PropertyName`.

Remember to adjust the component and property names according to your actual implementation. With this approach, you can pass complex objects (like your `Starship` class) as parameters to components in Blazor. 🚀

----

![Me](./Images/Copilot-Me.png)

I notice that in the portion of your sample `<StarshipProfile Ship="myStarship" />`, you did not use the `@` symbol for the `Ship` attribute. Is that correct, and if so, is it because Blazor recognizes that `<StarshipProfile />` is itself already a Blazor component? In other words, does Blazor parse the complex `Starship` type for the `Ship` attribute by automatically referencing the `myStarship` property instance in the `@code` block (in contrast, say to a `Count` attribute interpreting a literal `int` in something like `<Counter Count="9" />`)? Be precise and correct in your understanding of Blazor components in .NET 8.

![AI](./Images/Copilot-AI.png)

My apologies for any confusion in my previous response. Let's dive into the precise details of how Blazor components handle parameters, especially when dealing with complex types like your `Starship` class.

1. **Attribute Syntax**:
    - In Blazor, component parameters (attributes) can be specified using either of the following syntaxes:
        - **Without `@` Symbol**: When you pass a parameter without the `@` symbol (e.g., `<StarshipProfile Ship="myStarship" />`), Blazor interprets it as a **literal value**. This means that the value is treated as a constant and not evaluated as an expression.
        - **With `@` Symbol**: When you use the `@` symbol (e.g., `<StarshipProfile Ship="@myStarship" />`), Blazor treats it as an **expression**. The expression is evaluated, and its result is passed as the parameter value.

2. **Complex Types and Automatic Binding**:
    - When you pass a complex type (like your `Starship` class) as a parameter, Blazor automatically binds the parameter to the corresponding property in the component.
    - In your example, `<StarshipProfile Ship="myStarship" />`, Blazor recognizes that `myStarship` is an instance of the `Starship` class. It automatically binds the `Ship` parameter to the `myStarship` object.
    - This behavior is consistent with how Blazor handles complex types. You don't need to explicitly use the `@` symbol for complex objects; Blazor understands that you're passing an object reference.

3. **Literal Values vs. Expressions**:
    - For primitive types (like `int`, `string`, etc.), you can use either syntax. For example:
        - `<Counter Count="9" />` (literal value)
        - `<Counter Count="@myCount" />` (expression)
    - However, for complex types, using the `@` symbol is not required. Blazor automatically treats the parameter as an expression even without it.

In summary, when passing complex objects (like your `Starship` instance) as parameters to Blazor components, you can omit the `@` symbol. Blazor will correctly bind the parameter to the object reference. If you were passing a literal value (e.g., an `int`), then using the `@` symbol would be necessary.

Thank you for your attention to detail, and I hope this clears up any confusion! 🚀

----

