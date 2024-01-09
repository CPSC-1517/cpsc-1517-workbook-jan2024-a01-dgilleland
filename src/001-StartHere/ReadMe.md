# Start Here ![Code](https://img.shields.io/badge/Code%20Status-Walkthrough-blueviolet?logo=Visual%20Studio%20Code&labelColor=indigo)

> This presumes that you've installed the required software and have familiarized yourself with this workbook repository's content. Please review the [`ReadMe.md`](../../ReadMe.md) at the root of this repository for more information.

## Working In The Terminal

1. Open the terminal in Visual Studio Code by pressing <kbd>Ctrl</kbd> + <kbd>~</kbd>. This key combination is used to toggle the terminal between open and closed states. Note how the path in the terminal is the location that you have cloned your workbook.
   1. Ensure that you do **not** have your workbook in a folder that is synced with a cloud storage service (e.g.: OneDrive, Google Drive, etc.). This can cause issues with the version control system.
1. Open an external terminal window by pressing <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd>. This will open a terminal window that is not tied to Visual Studio Code. This is useful if you want to keep the terminal open while using the full editor space in Visual Studio Code.
1. There are several terminal commands that you should be familiar with. These are listed below.
   1. `cd` - Change Directory
   1. `ls` or `dir` - List the contents of the current directory
   1. `clear` or `cls` - Clear the terminal screen
   1. `exit` - Exit the terminal

## Version Control Setup

Perform the following steps in the terminal.

1. Type `git --version` to ensure that git is installed and available.
1. Type `gh --version` to ensure that the GitHub CLI is installed and available.
1. Type `git config --global user.name "Your Name"` to set your name for git (e.g.: `"Stewart Dent"`).
1. Type `git config --global user.email "Your Email"` to set your email for git (e.g.: `"stewdent@gmail.com"`)
1. Type `git config user.name` to view the name that you set.
1. Type `git config user.email` to view the email that you set.
1. Ensure that you are logged into GitHub.com in your default browser. Then, in the terminal, type `gh auth login` to authenticate the GitHub CLI.
   1. Follow the prompts to authenticate.
   1. You can use the `gh auth status` command to view your authentication status.

## Making Notes in Markdown + Your First Commit

> ***Note:** You will find that you have several `ReadMe.md` files in this repository (almost every folder has one). The reason for this is that GitHub will automatically display the contents of a `ReadMe.md` file when you navigate to a folder in the browser. This is a great way to provide information about the contents of a folder.*

1. Edit the `ReadMe.md` file at the root of this repository to enter your name in the space provided (line 3).
1. Under the [*`docs/mynotes`*](../../docs/mynotes/) folder, create a new file called `Journal.md`. In it, enter the following.

    ```md
    # Class Notes

    > Here is where I will enter general notes from my classes, including check-lists for my **practice homework** as well as **questions** I have for each upcoming class.

    ## Week 1 | Day 1

    TBD...
    ```

1. Move the [`git-commands.md` file](./git-commands.md) from its current folder to your *`mynotes/`* folder.
1. Edit the `ReadMe.md` file for your notes to include links to the two new files in your notes folder.
1. Commit these changes to your repository and synchronize it with the copy on GitHub.
1. In the terminal, type `gh browse` to open your repository in the browser. Ensure that your changes have been synchronized.
1. Part of your homework will be to review the **Mastering Markdown** resource.

## Editing Your GitHub Profile

1. In your browser, navigate to your GitHub profile.
1. Click the **Edit Profile** button.
1. Enter your actual name.
1. Add a profile picture as your Avatar. (optional)
1. Click the **Save** button to save your changes.

