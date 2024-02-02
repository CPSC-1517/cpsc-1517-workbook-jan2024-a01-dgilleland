# CPSC-1517 - **Student Workbook** (Jan 2024)

> **STUDENT_NAME**

## Schedule

> The following schedule is subject to change. Consult the course outline for the mark distribution. See the [Agenda](./Agenda.md) for details on upcoming and completed topics.

```mermaid
gantt
    dateFormat  YYYY-MM-DD
    title       CPSC-1520 | Scheduled Topics & Assessments
    %% excludes    weekends
    %% (`excludes` accepts specific dates in YYYY-MM-DD format, days of the week ("sunday") or "weekends", but not the word "weekdays".)

    section Topics
    %% done - for finished tasks
    %% active - for current tasks
    %% crit - for red outline/background
    Intro, git & Workbook     :active,  part0, 2024-01-09, 2024-01-10
    OOP Grammar Review       :         part1, 2024-01-11, 2d
    TDD      :         part2, after part1, 14d
    Files & LINQ          :         part3, after part2, 7d
    Blazor Intro          :         part4, after part3, 14d
    Reading Week              :         break, after part4, 7d
    More Blazor          :         part5, after break, 7d
    Client-Server Intro :        part6, after part5, 7d
    Client-Server Read/Display :        part7, after part6, 14d
    Client-Server Update/Delete :       part8, after part7, 21d
    In-Class Lab Time :        part9, after part8, 14d

    section In-Class Quizzes
    In-Class 1, Feb 14 :  milestone, 2024-02-14, 0d
    In-Class 2, Mar 20 :  milestone, 2024-03-20, 0d
    In-Class 3, Apr 17 :  milestone, 2024-04-17, 0d

    section Take-Home Exercises/Projects
    Ex 1, due Jan 28 : 2024-01-12, 2024-01-28
    Ex 2, due Feb 09 : 2024-01-26, 2024-02-09
    Ex 3, due Mar 15 : 2024-02-07, 2024-03-15
    Ex 4, due Apr 04 : 2024-03-15, 2024-04-04
    Proj Deliverable 1, due Apr 12 : 2024-03-15, 2024-04-12
    Proj Deliverable 2, due Apr 26 : 2024-03-28, 2024-04-26

```

----

## ![Inside This Repo](./docs/images/level.png) Inside this repository

This repository is your **Student Workbook** for participating in the in-class demos and for completing practice homework; the coding work is to be placed in the [*`src/`*](./src/ReadMe.md) folder. Learning Outcomes ([**LOGs**](./docs/learning_outcomes/ReadMe.md)) and other useful notes can be found in the [**docs** folder](./docs). Also, you are encouraged to use the [**docs/mynotes**](./docs/mynotes/ReadMe.md) folder to record your notes from each class.

> :warning: **Do *NOT*** use this repository for any assignments that are worth marks. :warning:

Additionally, you can find online notes at the course's [Moodle site](https://moodle.nait.ca).

<!--
> *There are old,  unofficial [website notes](https://cpsc-1517.github.io). These notes are no longer maintained, but may still be useful for some aspects of this course. You should remember that they contain content that references the older .NET Framework which is no longer taught in this course, so don't attempt to blindly apply content into material for the current iteration of this course.*
-->

----

## ![Version Control](./docs/images/tasks.png) Version Control

At the end of the term, your repositories on the [CPSC-1517 GitHub Organization](https://github.com/CPSC-1517) will be removed. You will still have access to your local versions of these repositories for your personal use and review.

> :warning: **Do *NOT*** re-publish your assignment/assessment repositories - doing so with any materials worth marks is an act of academic dishonesty :warning:


----

## ![Software et.al.](./docs/images/code.png) Software & Resources

Required tools for this course include:

- **.NET SDKs**
  - You should be prepared to have the appropriate versions of .NET Core SDKs (*Software Development Kit*) installed on your computer. You can find the latest versions at [dot.net](https://dot.net).
- **Command-Line Tools**
  - [**Git** for Windows/macOS/Linux](https://git-scm.com/downloads)
  - [**GitHub CLI**](https://cli.github.com/)
  - [**node**](https://nodejs.org/en/download/) (which includes **npm**) - Node is a run-time that allows you to use JavaScript on the web server. It comes along with npm (*Node Package Manager*), a package-management tool for the command line that allows you to integrate 3rd-party libraries with your application.
- **Visual Studio** - *Your Instructor may have a preference for which IDE you use.*
  - [Visual Studio Code](https://code.visualstudio.com) (see [Notes](./docs/ToolTips.md#vs-code) on VS Code extensions)
  - [Visual Studio 2022, Community Edition](https://visualstudio.microsoft.com/) (see [Notes](./docs/ToolTips.md#vs-2022-community) on the minimum version)
- [**LinqPad 8**](https://www.linqpad.net/Download.aspx) or higher
- **Database Tools**
  - [SQL Server 2022](https://www.microsoft.com/sql-server/sql-server-downloads) or higher, **Developer Edition**
    - If you are installing SQL Server on a Mac, follow the instructions in this article:
      - [How to Install SQL Server on a Mac](https://database.guide/how-to-install-sql-server-on-a-mac/)
    - You might also find this video useful:
      - [Step By Step Guide To Install MSSQL Server On Mac Using Docker](https://youtu.be/BVNWRYPv78o) (20 min, 27 sec)
  - Database Management Tools - *For a comparison, see these tables of [feture comparisons](https://learn.microsoft.com/en-us/azure-data-studio/what-is-azure-data-studio#feature-comparison-with-sql-server-management-studio-ssms).*
    - [SQL Server Management Studio](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15#download-ssms) (*SSMS*)

Additional recommended tools for this course include:

- **Version Control**
  - [GitHub CLI](https://cli.github.com/) (*Command-Line Interface*)
- **Drawing Tools**
  - A [LucidChart](https://www.lucidchart.com/pages/) free account, or Draw.io ([desktop](https://about.draw.io/integrations/#integrations_offline) and [online](https://draw.io) versions)
  - [Balsamiq Desktop](https://balsamiq.com/wireframes/desktop/) for mockups (*This is a commercial application*)

Other recommended resources include:

- [Learn Markdown](https://commonmark.org/help/)
- [Programming Fundamentals - An Object-Oriented Introduction to Programming in C#](https://programming-0101.github.io/TheBook/)

