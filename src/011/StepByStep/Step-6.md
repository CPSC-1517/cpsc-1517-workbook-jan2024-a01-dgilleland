# Filtered Search

- Search by Supplier, Category, or partial product name
  - https://aspnet.github.io/quickgridsamples/filtering

```razor
<ColumnOptions>
    <div class="search-box">
        <input type="search" autofocus @bind="nameFilter" @bind:event="oninput" placeholder="Country name..." />
    </div>
</ColumnOptions>
```
