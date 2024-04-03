# Database Update

> ![Est. Read Time](https://img.shields.io/badge/Read%20Time-5%20min-brightgreen)
> ![Est. Code Time](https://img.shields.io/badge/Code%20Time-15--25%20min-blue)


Whether you are adding new products or updating existing products, the set of user input controls is the same. We'll expand the capabilities of the `Edit.razor` page to support updating by making some changes and additions to the current form.

## Add `UpdateProduct`

To prepare for updating products, we'll add yet another method to the `ProductServices` class in the BLL.

```cs
public void UpdateProduct(Product item)
{
    _context.Products.Update(item);
    _context.SaveChanges();
}
```

## Readying Our Edit Page

In order to know what product we are updating, our `Edit.razor` page needs to receive a product id. We'll support that through a change to the URL that routes to our page. Change the first line of `Edit.razor` to match the following.

```razor
@page "/Product/Edit/{id:int?}"
```

Additionally, we will need another property in our `@code { }` block to store that value.

```cs
    [Parameter]
    public int Id { get; set; }
```

With this extra information, we can change the first part of our initialzation method to check and see if we've been given a product id. If so, then we will load that data as our model, which will pre-fill that information in our form.

```cs
protected override void OnInitialized()
{
    if(Id > 0)
    {
        Product = ProductDbServices.GetProduct(Id);
    }
    else
    {
        Product = new();
    }
    Categories = CategoryDbServices.GetAllCategories();
    Suppliers = SupplierDbServices.GetAllSuppliers();
}
```

Just to make sure that our page is getting good data to work with, we'll expand on our ad-hoc *diagnostics* block at the bottom of the page.

```razor
<blockquote>
    <h4>Diagnostics</h4>
    <ul>
        <li>User Feedback: "@UserFeedback"</li>
        <li>Product Id: @Id</li>
    </ul>
</blockquote>
```

## Revisiting the Product Catalog

How will we choose which product we are editing? The easiest way to do that is to revisit our Product Catalog - `ProductData/Index.razor`.

Inside the `<QuickGrid>`, we'll add a *Template Column* where we'll have a link to our edit page for each product listed in the grid.

```razor
<TemplateColumn Title="Edit" >
    <a href="/Product/Edit/@(context.ProductId)"><i class="las la-edit"></i></a>
</TemplateColumn>
```

Test out the navigation we've added. You should be able to grab the exiting information for any product so that it can be edited.

## Updating vs. Adding

Our form's button currently says "Add", but we would want it to say "Update" if we have an existing product. Let's make the following modifications to the `Edit.razor` page.

```razor
<button type="submit">@(Id > 0 ? "Update" : "Add")</button>
```

The form's submission will call the same method for an Add as well as an Update. Let's modify our code to distinguish between these two operations.

```cs
private void SaveValidProduct()
{
    try
    {
        if (Id == 0)
        {
            Id = ProductDbServices.AddProduct(Product!);
            UserFeedback = $"Product details have been added and assigned an Id of {Id}";
            Product = new();
            Id = 0;
        }
        else
        {
            ProductDbServices.UpdateProduct(Product!);
            UserFeedback = "Product details have been modified.";
        }
    }
    catch (Exception ex)
    {
        UserFeedback = $"Unable to save product information: {ex.Message}";
    }
}
```

## Form Behaviour

What should happen after adding or updating a product. Should the form be "cleared" in either case? Or should an "add" retain the information in the form and auto-switch to "update" mode? In either case, how do we show These are questions that we should consider as we refine our page's behaviour. These are also the kinds of questions we should be asking as part of crafting a good **User eXperience** (*UX*).

> *:octocat: **Commit** your work now. :grey_exclamation:*

The next step in our CRUD app is to support [deleting products](./Step-5.md).
