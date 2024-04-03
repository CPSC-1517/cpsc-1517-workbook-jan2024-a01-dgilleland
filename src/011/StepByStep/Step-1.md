# A CRUD-Based Application

> ![Est. Read Time](https://img.shields.io/badge/Read%20Time-6%20min-brightgreen)
> ![Est. Code Time](https://img.shields.io/badge/Code%20Time-18--30%20min-blue)

The core database operations are the *Create, Read, Update and Delete* (CRUD) tasks to work with table data. The operations that *modify* the database are the *Create, Update and Delete*, and these are commonly done on a table-by-table basis. *Read* operations will sometimes involve grabbing data from a single table, but more often than not they will require getting data from more than one table (a *de-normalizing* effect, if you will).

As a CRUD-based application, we will generate a separate class for each table that will focus on providing methods to perform each of these operations. We will call these our *Service* classes.

Our first focus will be on the **Products** table data, and supporting CRUD operations. What you learn in this series will be applicable to just about every table in any database.

## CRUD Services

Begin by creating a folder in your class library project named `BLL`. *BLL* is an acroynm for *Business Logic Layer* (though, in truth, we don't really have any notable "business logic" in a simple CRUD application). Inside of that folder, create a class called `ProductServices`. We'll also add in some `using` statements that will come in handy later on.

```cs
using WestWindWholesale.DAL;
using WestWindWholesale.Models;
using Microsoft.EntityFrameworkCore;

namespace WestWindWholesale;

public class ProductServices
{
}
```

The class will need access to the database via our *DAL* (*Data Access Layer*) class called `WestWindContext` in order to perform our CRUD operations. We will use what's known as a ***dependency injection*** pattern where the outside "users" of our class will supply the actual instance of `WestWindContext`. Add the following property and constructor to `ProductServices`.

```cs
private readonly WestWindContext _context;
internal ProductServices(WestWindContext context)
{
    _context = context;
}
```

## Exposing our Services

While our `ProductServices` class is publicly available, you may have noticed that its constructor is declared as `internal`. This is purposeful. We will want to control how it is instantiated while still allowing external users the ability to supply the details of our database's location, login, etc. In other words, we'll continue our *dependency injection* pattern all the way up to our front end application.

Create a new `static` class named `WestWindServices` in the root of your class library project. In it, add a single method.

```cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindWholesale.DAL;

namespace WestWindWholesale;

public static class WestWindServices
{
    public static void WWBackendDependencies(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<WestWindContext>(options);

        services.AddTransient<ProductServices>((serviceProvider) =>
        {
            var context = serviceProvider.GetService<WestWindContext>();
            return new ProductServices(context!);
        });
    }
}
```

We will add more services through this method later on.

## Configuring our Services

Our Blazor web application will need access to these services. Inside the `Program.cs` file, add the following lines in the context indicated. You will also need a `using WestWindWholesale;` at the top of `Program.cs`.

```cs
var builder = WebApplication.CreateBuilder(args);

#region Configure our backend system
var connectionString = builder.Configuration.GetConnectionString("WWDB");
builder.Services.WWBackendDependencies(options =>
	options.UseSqlServer(connectionString));
#endregion

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

Now, modify the `appsettings.Development.json` file to contain the connection string details for your database. These details are probably present in your `WestWindContext` class' `OnConfiguring` method.

```cs
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=WestWind;Trusted_Connection=True;TrustServerCertificate=True");
```

Take the string data from this method and put it in the `appsettings.Development.json` as shown below. Then, **remove** the `OnConfiguring` method entirely.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "WWDB": "Data Source=.;Initial Catalog=WestWind;Integrated Security=True;TrustServerCertificate=true"
  }
}
```

> ***Note:** If your database is in a named instance, such as `SQLEXPRESS`, you will need to make sure you properly convert your C# string to an ordinary string by removing the escape character (`\`). E.g.: `Server=.\SQLEXPRESS`.*

> *:octocat: **Commit** your work now. :grey_exclamation:*

With all of this background setup in place, let's move on to our first database operation: [Reading Products](./Step-2.md).
