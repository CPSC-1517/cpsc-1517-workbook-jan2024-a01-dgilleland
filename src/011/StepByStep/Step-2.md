# Database Read

We will provide two methods to read Product data from the database. The first will get all the products. The second will get a single product based on the Id.

```cs
public List<Product> GetProducts()
{
    return _context.Products.ToList();
}
```

```cs
public Product? GetProduct(int productId)
{
    return _context.Products.Find(productId);
}
```

> *:octocat: **Commit** your work now. :grey_exclamation:*

## Displaying Products

> ***Note:** After each code change, you should be able to see the results in your browser. If you don't see any changes, you may need to rebuild. In the terminal that is running `dotnet watch`, press <kbd>ctrl</kbd> + <kbd>r</kbd> to rebuild/reload.*

To display the products, we will use a `QuickGrid` component in our `ProductData/Index.razor` page. Begin by changing the first few lines of your file to match the following.

```razor
@page "/Product/Index"
@rendermode InteractiveServer
@using WestWindWholesale
@using WestWindWholesale.Models
@using Microsoft.AspNetCore.Components.QuickGrid
@inject ProductServices ProductDbServices

<PageTitle>Product Catalog</PageTitle>
```

In the code block, add the following to grab all the product data.

```cs
private IQueryable<Product>? Catalog { get; set; }
protected override void OnInitialized()

{
    Catalog = ProductDbServices.GetProducts().AsQueryable();
}
```

Just to make sure everything is wired up correctly, add a little diagnostics block at the end of the page. (We can remove this when we are done creating our table.) View the page to see if you get a count of products in the database.

```razor

<blockquote>
    <h4>Diagnostics</h4>
    <ul>
        <li>Product Count: @Catalog?.Count()</li>
    </ul>
</blockquote>
```

Add a `QuickGrid` component that will display the items. Begin with a single column's worth of data.

```razor
<QuickGrid Items="Catalog">
    <PropertyColumn Property="@(item => item.ProductName)" Title="Product Name" />
</QuickGrid>
```

If the data is displaying correctly, add in some more columns.

```razor
<PropertyColumn Property="@(item => item.UnitsOnOrder)" Align="Align.Center" Title="On Order" />
<PropertyColumn Property="@(item => item.QuantityPerUnit)" Title="Qty/Unit" />
<PropertyColumn Property="@(item => item.UnitPrice)" Format="c" Align="Align.Right" Title="Unit Price"/>
```

> ### Column Alignment
>
> If you are not using Bootstrap, then the column alignments might not be working. I added the following `<style>` tag to help recitfy that.
>
> ```html
> <style>
>     .col-justify-right {
>         text-align: right;
>     }
>     .col-justify-center {
>         text-align: right;
>     }
> </style>
> ```

## Pagination Support

You should notice that the list of products is quite large. A better display option would be to add pagination into the mix. Begin by adding the following field to your code block.

```cs
PaginationState Paginator = new PaginationState { ItemsPerPage = 10 };
```

Add the `Pagination="@Paginator"` attribute to your `<QuickGrid>`.

```razor
<QuickGrid Items="Catalog" Pagination="@Paginator">
```

You should now be seeing the first 10 items on the page.

Immediately *after* your QuickGrid `<QuickGrid>` component, add in the `<Paginator>` component to provide navigation between the pages.

```razor
<Paginator State="@Paginator" />
```

View your page and see if you can navigate between the pages.

Lastly, you can add in a simple drop-down to allow the user to choose their page size.

```razor
<div class="page-size-chooser">
    Items per page:
    <select @bind="@Paginator.ItemsPerPage">
        <option>5</option>
        <option>10</option>
        <option>20</option>
        <option>50</option>
    </select>
</div>
```

> ### Styling Your Page Size Drop-Down
>
> Consider adding the following to your styles for the page.
>
> ```css
> .page-size-chooser {
>     display: flex;
>     align-items: center;
>     margin-bottom: 1rem;
> }
>
> .page-size-chooser select {
>     margin: 0 1rem;
>     padding: 0.25rem 0.5rem;
> }
> ```

## Sorting Support

The `<QuickGrid>` supports automatic sorting of data by column. Add a `Sortable="true"` attribute to your `<PropertyColumn>` tags for the *Product Name* and the *Unit Price*.

> ### Styling Title Buttons for Sortable Columns
>
> The `<QuickGrid>` uses buttons for the titles that can be sorted. You can style this to work with PicoCSS by adding the following to your `<style>` tag.
>
> ```css
> .quickgrid button.col-title {
>     background-color: var(--pico-primary-background);
> }
> .quickgrid[theme=default] button.col-title:hover {
>     background-color: rgba(128, 128, 128, 0.8);
> }
> ```

This produces a fairly complete tabular representation of all the WestWind products. It's time to move on to the [edit page](./Step-3.md).

> *:octocat: **Commit** your work now. :grey_exclamation:*
