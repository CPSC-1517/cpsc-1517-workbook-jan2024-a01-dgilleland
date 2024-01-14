# About TLPs

In the release of .NET 9 (Nov, 2020), Microsoft introduced [**Top-Level Program**](./AboutTLPs.md) files (*TLP*s) to C# as a lighter alternative to the standard way of coding the entry point of our application.

## Background

Historically, we created the entry point of our application by making a `Program` class with a static `Main` method. That `Main` method would typically have a single parameter (`string[] args`) and have a delared return type of either `void` or `int`. But the thing that we really cared about was the body of the `Main` method. That's where we would put the code that we wanted to run when our application started.

All of the code surrounding the body of the `Main` method was just boilerplate code that was required to get our application to run. If all you were doing inside the `Main` method was to act as a "driver" for the application, then it can seem that all that boilerplate code is unnecessary. By the time you've created your fourth or fifth console application, you can be forgiven if you've thought, "Do we *always* have to do this?"

Of course, since C# is an object-oriented programming language, the answer is "Yes, it's all necessary." For many, that made the entry level to C# programming a little steep. Most instructors would just focus on the body of the `Main` method and say, *"Ignore all the other stuff."*

Eventually, Microsoft made it easier by adding in some compiler-level processing magic. Voilà: Top-Level Programs (TLPs) were born!

## How it Works

In any given executable project, it is now possible to have your entry-point file as a top-level program. This means that you can have a file that contains the body of the `Main` method without the boilerplate of a class or the `Main` method's signature. In reality, C# still requires the method delcaration inside of a class, but this is accomplished for you by some compiler-based "sleight-of-hand". When you build the project, the compiler just takes the code from that file and wraps it back into that same type of boilerplate code. This means that you can simply focus on what you want your application to do once it starte, as in the following example.

```cs
using System;
Console.WriteLine("Hello World!");
```

It's important to note that [you can only have one top-level program](https://aka.ms/new-console-template) per project. If you try to add another top-level program, you'll get a compiler error.

## The Rest of Program.cs

But what about the rest of what we might have placed inside our `Program` class? Is there still an `args` parameter (*short answer: Yes*)? What about a return value for the `Main` method (*you did know that `Main` can return a value, right?*)? And what about having properties, fields, and other methods inside the `Program` class? Can we still do that (*short answer: Not really*)?

You don't need to do anything special to have a top-level program file. As the compiler reads the source code files, if it detects a file without the class and method wrappers, it assumes that is the top-level program and it marks it as the entry point of the whole application (which is why you can only have one top-level program file in a single project).

## The `args` Parameter

You don't have to do anything special to get the `args` parameter. All you need to do is to make use of it, and the compiler will add it in for you in the final compiled code. For example, if you want to loop through the `args` parameter, you can do so like this:

```cs
foreach (var arg in args)
{
    Console.WriteLine(arg);
}
```

## The Return Value of `Main`

Just like the `args` parameter, you don't have to do anything special in order to have a return value for your `Main` method. All you need to do is to return a value from the `Main` method, and the compiler will add it in for you in the final compiled code. For example, if you want to return an exit code of `0` from the `Main` method, you can do so like this:

```cs
return 0; // Everything's good!
```

And, if you want to return some sort of error code, you can do so like this:

```cs
return 1; // Uh oh! Something went wrong!
```

If you don't return a value at the end of your `Main` method, the compiler will just assume that there isn't anything important about exiting your application. In other words, it will assume that your entry-point method simply returns a `void`, and it will compile it accordingly.

## Fields, Properties and Methods

Once of the prices you pay for using TLPs is that you cannot have the other class-level characteristics of your `Program` class, such as fields, properties, constructors and methods. This shouldn't be a problem, as a typical application only uses the main entry point as a "driver" to keep the program alive as long as it's in use. Most of the actual work of a typical application is done in other classes and methods.

What you might not be aware of is that the C# language allows you to declare methods *within* other methods. These are known as *local functions* or *nested methods*. They will not have an access modifier (such as `public` or `private`), and they will only be accessible within the method in which they are declared. This means that you can still have methods that are only used within your `Main` method, as in the following example.

```cs
using System;

if (args.Length == 0)
    SayHello("World");
else if (args.Length == 1)
    SayHello(args[0]);
else
    foreach(string arg in args)
        SayHello(arg);

// Here's a local function nested inside the Main method
void SayHello(string name)
{
    Console.WriteLine($"Hello, {name}!");
}
```

## A Word About `async`

If you're just starting your C# journey, odds are you aren't even aware of the concepts of synchronouse versus asynchronous code. If you are aware of them, then you might be wondering how you can use `async` and `await` in a top-level program. The answer is that you simply perform any `await` calls as needed, and (once again) the compiler will infer that the entry point should be `async` and it will compile it accordingly.
