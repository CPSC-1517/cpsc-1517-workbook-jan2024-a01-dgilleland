# Filtered Search

> ![Est. Read Time](https://img.shields.io/badge/Read%20Time-3%20min-brightgreen)
> ![Est. Code Time](https://img.shields.io/badge/Code%20Time-9--15%20min-blue)

Currently, our product catalog page lists all the products in the database. But what if we want a subset of items to be displayed? We can add a *filter* for our catalog. Let's explore that by searching for products whose name contains part of what the user has entered.

## Add to the Product Services

Add the following method to `ProductServices` in the BLL.

```cs
public List<Product> GetProductsByProductName(string partialName)
{
    return _context.Products
        .Include(p => p.Supplier)
        .Include(p => p.Category)
        .Where(p => p.ProductName.Contains(partialName))
        .ToList();
}
```

## Enabling our Filter

We'll add our search filter to the Product Name column header. But first, let's get a couple of items in place. We will need to have a property to hold the partial product name and a method to call our BLL method. Add the following to the `ProductData/Index.razor` code block.

```cs
  private string? PartialProductName;
```

```cs
  private void UpdateFilter()
  {
      if(string.IsNullOrWhiteSpace(PartialProductName))
      {
          Catalog = ProductDbServices.GetProducts().AsQueryable();
      }
      else
      {
          Catalog = ProductDbServices.GetProductsByProductName(PartialProductName.Trim()).AsQueryable();
      }
  }
```

Next, we'll modify the `<PropertyColumn>` that correlates to the `ProductName` data in the table.

```razor
<PropertyColumn Property="@(item => item.ProductName)" Title="Product Name" Sortable="true">
    <ColumnOptions>
            <div class="search-box">
                <input type="search" autofocus @bind="PartialProductName" @bind:event="oninput" @bind:after="UpdateFilter" placeholder="Partial name..." />
            </div>
        </ColumnOptions>
</PropertyColumn>
```

That's all we need to do to add in some filtering! Here's a [short article](https://blog.sigmasolid.dk/blog/quickgrid%20in%20blazor%20is%20awesome/) that helped me in building this filtering. You should note that performing a filter operation like this will involve additional calls to the database. Optimization concerns will be addressed in another set of tutorials.


> *:octocat: **Commit** your work now. :grey_exclamation:*

The last step will involve a little [formatting and organizing](./Step-7.md) of our input form.
