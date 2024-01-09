# Learning Outcome Guides (**LOG**s)

> Your instructor will be making use of Learning Outcome Guides throughout the course. For individual classes, some of those will come from the [legacy course website](https://cpsc-1517.github.io/logs/) and others will be provided in-class. In either case, you are encouraged to copy them into this file or folder as your personal reference and to make brief notes on each outcome to help solidify your learning experience.

- **Table of Contents**

## Introduction to IDEs

> *This is a sample LOG with personal notes under each major bullet item.*

At the end of this topic, you should be able to:

- Define the term IDE: **Integrated Development Environment**
  - An IDE is a tool that helps you write code. It provides a text editor, a compiler, a debugger, and other tools that help you write code.
- Identify three popular IDEs for coding in C#
  - Visual Studio Code (with extensions)
  - Visual Studio 2022
  - JetBrains Rider
- Define the term CLI: **Command Line Interface**
  - A CLI is a tool that allows you to interact with your computer using text commands in a terminal window.
- Identify the CLI tools used in this course
  - `dotnet` - The .NET SDK CLI (underlying tool for Visual Studio and VS Code)
  - `git` - The Git CLI
  - `gh` - The GitHub CLI

### Visual Studio 2022

- List the key tools available in Visual Studio
  - Editor with intellisense
  - Debugger
  - Compiler & Runtime Execution
  - "Solution Explorer" - Manage the projects/files that are part of your solution
    - Shows a "logical" representation of the things in the whole solution
- Describe the primary parts of the IDE used: Editor Window, Toolbox, Solution Explorer, Server Explorer, Error List, Output Window
- Create a Web Application Project
- Create a Class Library project
- Create a blank solution
- Configure the tool options in Visual Studio

### Visual Studio Code

- Describe how VS Code differs from Visual Studio 2022
  - VS Code is a "lightweight" IDE
  - VS Code is cross-platform
  - VS Code is open-source
  - VS Code is extensible
- Describe the primary parts of the IDE used: Editor Window, Explorer, Terminal, Output Window
- Describe how to add/remove extensions in VS Code
- List the extensions recommended for this course
- Complete the Walkthroughs in the Welcome page
- Access the `dotnet` command line tools from the integrated terminal
- List the project template(s) available through the `dotnet` CLI

----

## C# Project Types

- Identify the file extension for a C# Solution file
- Identify the file extension for a C# Project file
- Describe the relationship between Solutions, Projects and Files in Visual Studio
  - The `.sln` file (solution file) lists the projects in a solution
  - Individual projects list their contents/settings in a `.csproj` file.
- List three different types of projects (because of C#, they will have the `.csproj` extension) used in this course
  - Console applications - The compiled program has the file extension `.exe` - this program has a `Main()` method
  - Class Libraries - The compiled project has `.dll` (Dynamically Linked Library) - they can have LOTS of Classes
  - Web Applications - Web applications deliver their content via a **Web Server**
- List the project template(s) used to create the types of projects used in this course
