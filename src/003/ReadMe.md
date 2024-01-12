# C# Apps - Projects and Solutions


----

### Demo

#### Creating a Console Application

1. Open up a terminal window in the root of your repository. For example, if your repository folder is called `cpsc-1517-workbook-jan2024-a02-stewdent` and it is in the `C:\GH\CPSC-1517\` folder of your local computer, then your terminal window should look like this:

    ```ps
    C:\GH\CPSC-1517\cpsc-1517-workbook-jan2024-a02-stewdent>
    ```

1. The primary tool we use in the terminal to create, configure and run projects in DotNet is `dotnet`. It's the CLI that runs under-the-hood with Visual Studio 2022, but we can work with it directly in the terminal. Let's explore the help information.

    ```ps
    dotnet --help
    ```

1. Notice that one of the subcommands of the `dotnet` CLI is the `new` command. We can discover help information on subcommands as well.

    ```ps
    dotnet new --help
    ```

1. Commands in a CLI can have **subcommands**, **arguments** and **options**.
   1. Subcommands in the `dotnet` CLI can have subcommands. The DotNet CLI has a *lot* of subcommands!
   1. Arguments are data that are passed into the commands.
   1. Options are typically seen as beginning with a double-dash, as in the `--dry-run` option for `dotnet new`. Sometimes options will have an alias that uses a single dash; for example, the `--name <name>` has an alias of `-n`. Options can also have arguments, just like the `--name` option has.

1. Observe the output from running the following command in the terminal

    ```ps
    # Run from the root of your student workbook
    dotnet new console --dry-run -o src/003/HelloWorld -n App
    ```

1. Try another command. This time, observe the output from a dry-run of creating a solution.

    ```ps
    dotnet new sln --dry-run -o src/003/ -n MyApp
    ```

1. Let's try those commands again, but without the `--dry-run` option.

    ```ps
    dotnet new console -o src/003/HelloWorld -n App --use-program-main
    dotnet new sln -o src/003/ -n MyApp
    ```

   Take some time to examine the contents of the `App.csproj` and `MyApp.sln` files. Notice we added another flag: `--use-program-main`. What do you think this does?

1. Navigate to the `~/src/003` folder in your terminal. Then run the following command.

    ```ps
    dotnet sln add HelloWorld/App.csproj
    ```

    Now see what has changed in the `MyApp.sln` file. Notice that we ran the `dotnet sln add` command while in the same folder as the `MyApp.sln` file. This was so that we didn't have to tell the command where to find that solution file: it will "assume" there is a single solution file in the current directory and then use that when adding in the project.

1. It's time to build the project.
   1. Observe what files/folders exist inside the `HelloWorld` folder.
   1. Type `dotnet build` in the terminal.
   1. Re-examine the files/folders inside `HelloWorld`. What changed?

1. Now, it's time to run the project: Type `dotnet run`.

#### Setting Up a Multi-Root Workspace

> Because we are using multiple solutions inside of our repository, it's best to keep them distinct in terms of the settings needed for running the solutions. To do this, we will work with multi-root workspaces.
>
> For more information, read the following:
>
> - [VS Code IDE and Workspaces](https://code.visualstudio.com/docs/editor/workspaces)
> - Multiple solutions in a single repository are easier to manage with [Multi-Root Workspaces](https://code.visualstudio.com/docs/editor/multi-root-workspaces) in VS Code.

In VS Code, select *"Save Workspace As..."* from the *File* menu to prepare your workbook for workspaces. Then, select *"Add Folder to Workspace..."* from the *File* menu and add in the `~/src/003/` folder. Make note of how that affects the appearance of the repository in the Explorer view.

#### Adding in some parameters to your console app

- [ ] In the main function, loop through and list the args that were passed in. If none were passed in (`args.Length == 0`), then display an appropriate message.
- [ ] Run the app and pass in some args with `dotnet run -- "Stewart Dent" honours DMIT`

#### Creating a Console App as a Top-Level Program (TLP)

- [ ] Create an app under `~/src/004/` without `--use-program-main` and without a solution. A stand-alone project does *not* need a solution file!
- [ ] See if the `args` variable is present. It is!

#### Throw-Away Projects

- [ ] `.gitignore`: the `RnD` and `NoTrack` folders

#### Organizing Your Demos

- [ ] Edit the `~/src/ReadMe.md` to have links and brief summaries for each of the demos