# Demos, Tutorials and Practice Materials

> You are encouraged to treat this folder as a **working directory** for demos, tutorials and practice assignments.
>
> :warning: **Do *NOT*** use this repository for any assignments that are worth marks. :warning:

## Instructor-Supplied Code Samples


If there is a sample in your instructor's workbook that you want to pull into your own workbook, the easiest way to do that is through a Node package called [**tiged**](https://github.com/tiged/tiged#readme). Here's an example of how to use it to [grab a subdirectory](https://github.com/tiged/tiged#specify-a-subdirectory) from your instructor's workbook:

```bash
$ npx tiged --disable-cache --force DMIT-1234/Instructor-Workbook/src/008/demo-events ./src/008/demo-events
//\_______________________________/ \_______________________________________________/ \___________________/
//      |- Command to run               |- Instructor's source folder (on GitHub)        |- Your local destination folder
```


A more detailed explanation of the command would look like this:

```bash
$ npx tiged --disable-cache --force DMIT-1234/Instructor-Workbook/src/008/demo-events ./src/008/demo-events
//\_/ \___/ \_____________/ \_____/ \_______/ \_________________/ \_________________/ \___________________/
// |    |          |          |       |             |                     |                     |- Destination folder
// |    |          |          |       |             |                     |- Instructor's sub-folder
// |    |          |          |       |             |- Name of Instructor's Repo
// |    |          |          |       |- GitHub Organization or User
// |    |          |          |- Force overwrite of existing files
// |    |          |- Disable caching of repo (so you grab the latest version)
// |    |- Command to run
// |- npx is a Node package runner (comes with Node)
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
