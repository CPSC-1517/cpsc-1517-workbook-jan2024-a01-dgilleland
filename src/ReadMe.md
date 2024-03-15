# Demos, Tutorials and Practice Materials

[Jump to the list of Workbook Demos](#workbook-demos)

> You are encouraged to treat this folder as a **working directory** for demos, tutorials and practice assignments.
>
> :warning: **Do *NOT*** use this repository for any assignments that are worth marks. :warning:

## Instructor-Supplied Code Samples

If there is a sample in your instructor's workbook that you want to pull into your own workbook, the easiest way to do that is through a Node package called [**tiged**](https://github.com/tiged/tiged#readme). Here's an example of how to use it to [grab a subdirectory](https://github.com/tiged/tiged#specify-a-subdirectory) from your instructor's workbook:

```bash
$ pnpm dlx tiged --disable-cache --force DMIT-1234/Instructor-Workbook/src/008/demo-events ./src/008/demo-events
//\____________________________________/ \_______________________________________________/ \___________________/
//      |- Command to run               |- Instructor's source folder (on GitHub)        |- Your local destination folder
```


A more detailed explanation of the command would look like this:

```bash
$ pnpm dlx tiged --disable-cache --force DMIT-1234/Instructor-Workbook/src/008/demo-events ./src/008/demo-events
//\______/ \___/ \_____________/ \_____/ \_______/ \_________________/ \_________________/ \___________________/
// |    |          |          |       |             |                     |                     |- Destination folder
// |    |          |          |       |             |                     |- Instructor's sub-folder
// |    |          |          |       |             |- Name of Instructor's Repo
// |    |          |          |       |- GitHub Organization or User
// |    |          |          |- Force overwrite of existing files
// |    |          |- Disable caching of repo (so you grab the latest version)
// |    |- Command to run
// |- pnpm dlx is an equivalent of the Node npx package runner
```

----

## Self-Improvement

**How** are you going to learn to write good code?

- **Read** good(ish) code
- **Play** in a "sandbox"
- **Study** by watching good videos and reading good books

There are three things you must continually master as you go through your IT career.

- Know the **problem** you are trying to solve
- Know your **programming language** and environment
- Know your **tools**

----

## Workbook Demos

### :100: In-Class Demos and Practice

- 000 - Course Introduction
- 001 - VS Code, the Terminal, and Markdown
- 002 - More Markdown
- 003 - Intro to C# in VS Code: Projects and Solutions
- 004 - Top-Level Programs
- 005 - Assorted C# Classes and Unit Tests
- 006 - Blazor Intro
- 007 - Blazor Empty Templates
- 008 - HTML Form Elements in Blazor

| Week | Demos :+1: |
|:----:| ----- |
| 1    | [000](./000/ReadMe.md), [001 Start Here](./001-StartHere/ReadMe.md), [002](./002/ReadMe.md), [003](./003/ReadMe.md) |
