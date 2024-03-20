# About EF Core

> I asked Microsoft's Copilot about EF Core. Here's the conversation.
>
> *Caveate: I haven't reviewed this yet for correctness.*

![Me](./Images/Copilot-Me.png)

Can you give me a very brief overview of what Entity Framework Core is? I want to use it as an introduction for my students.

![AI](./Images/Copilot-AI.png)

Certainly! **Entity Framework Core (EF Core)** is a powerful tool for .NET developers to interact with databases using .NET objects. Here's a concise overview:

1. **What Is EF Core?**
   - **EF Core** is a lightweight, open-source, and cross-platform version of the popular **Entity Framework** data access technology.
   - It serves as an **object-relational mapper (O/RM)**, bridging the gap between your .NET code and the database.
   - Key Features:
     - **Database Abstraction**: Allows you to work with databases using .NET objects, eliminating the need for extensive data-access code.
     - **Cross-Platform**: Runs seamlessly on Windows, Linux, and Mac.
     - **Model-Based Approach**: Data access is performed using a model composed of entity classes and a context object.
     - **Model Development Approaches**:
       - Generate a model from an existing database.
       - Hand-code a model to match the database schema.
       - Use **EF Migrations** to evolve the database as the model changes.
   - Example Model (C#):
     ```csharp
     public class BloggingContext : DbContext
     {
         public DbSet<Blog> Blogs { get; set; }
         public DbSet<Post> Posts { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
         }
     }

     public class Blog
     {
         public int BlogId { get; set; }
         public string Url { get; set; }
         public int Rating { get; set; }
         public List<Post> Posts { get; set; }
     }

     public class Post
     {
         public int PostId { get; set; }
         public string Title { get; set; }
         public string Content { get; set; }
         public int BlogId { get; set; }
         public Blog Blog { get; set; }
     }
     ```
2. **Querying Data**:
   - Retrieve instances of your entity classes from the database using **Language Integrated Query (LINQ)**.
   - Example (C#):
     ```csharp
     using (var db = new BloggingContext())
     {
         var blogs = db.Blogs
             .Where(b => b.Rating > 3)
             .OrderBy(b => b.Url)
             .ToList();
     }
     ```
3. **Saving Data**:
   - Create, delete, and modify data in the database using instances of your entity classes.
   - Example (C#):
     ```csharp
     using (var db = new BloggingContext())
     {
         var blog = new Blog { Url = "http://sample.com" };
         db.Blogs.Add(blog);
         db.SaveChanges();
     ```
4. **Best Practices**:
   - While EF Core abstracts many details, understanding the underlying database server is essential for high-performance production apps.

Feel free to explore more about EF Core on [Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/) or dive into your first app using [this tutorial](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app) ³⁴.

Source: Conversation with Bing, 2024-03-20

(1) [![favicon](./Images/76f43994-6f28-4167-9da6-1a5cfc2f6f75.png) Overview of Entity Framework Core - EF Core | Microsoft Learn.](https://learn.microsoft.com/en-us/ef/core/)

(2) [![favicon](./Images/76f43994-6f28-4167-9da6-1a5cfc2f6f75.png) Getting Started - EF Core | Microsoft Learn.](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app)

(3) [![favicon](./Images/5741c45b-43ad-4c5e-b5f7-012abfdd2c97.png) EF Core Overview - Entity Framework Core.](https://entityframeworkcore.com/overview)

(4) [![favicon](./Images/1b1038f7-ce78-4255-afc4-a2a0c6ccf9c9.png) Bing](https://bing.com/search?q=Entity+Framework+Core+overview)

(5) [![favicon](./Images/77cdf5bb-84c5-426f-92e9-3d026c50cf3b.png) DotNetTutorials](https://dotnettutorials.net/lesson/entity-framework-core/)

(7) [github.com.](https://github.com/claudineij-ciandt/dotnet-training/tree/f5a40d7a50f5ab8c2794a157ec70ecb026706074/aspnet-core%2Fconceitos%2Fentity-framework%2FREADME.md)

(8) [github.com.](https://github.com/Delizald/study-notes/tree/832de5e9f4c458926d447b0ef895bdeac6ad9bed/dotnetcore%2FEntityFramework%2Fintro.md)

(9) [github.com.](https://github.com/dotnet/EntityFramework.Docs/tree/f87e0a3a4b693bb1fda410842114f8a9a840f38c/samples%2Fcore%2FIntro%2FModel.cs)

(10) [github.com.](https://github.com/abalbin/202104-web/tree/1a86a2d653f9ca7a839f3d63c0784b334ef884ff/DemoBackend%2FDemoBackend%2FModels%2FBloggingContext.cs)

(11) [github.com.](https://github.com/MagdyH/Form-with-editable-grid--react-redux-apidotnetcore-using-ES6/tree/bf78188950649972e5dd8f9cc8f7cb9b84732e99/ReactAPI%2FEntity%2FModels%2FModel.cs)
