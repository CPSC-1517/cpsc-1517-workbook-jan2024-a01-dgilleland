# Installing Databases

Your database(s) will be provided as either *`.bacpac`* or *`.dacpac`* files. These files can be used to create or restore a database on your database server. The process can be completed through *SSMS* or the command line.

## Installing a `*.bacpac`

Open **SSMS** (*Sql Server Management Studio*) and begin by right-clicking on the `Databases` folder and selecting **Import Data-tier Application...**. Follow the steps of the dialog to select your *.bacpac* and install it on your database server.

![Step 1](./Images/01-right-click.png)

![Step 2](./Images/02-import.png)

![Step 3](./Images/03-import-bacpac.png)

![Step 4](./Images/04-import-settings.png)

![Step 5](./Images/05-import-summary.png)

![Step 6](./Images/06-import-results.png)

![Step 7](./Images/07-import-check-version.png)

----

## Installing a `*.dacpac`

Open **SSMS** (*Sql Server Management Studio*) and begin by right-clicking on the `Databases` folder and selecting ***Deploy* Data-tier Application...**. Follow the steps of the dialog to select your *.dacpac* and install it on your database server.

![Step 1](./Images/01-right-click-dacpac.png)

The remaining steps are similar to the ones for the `.bacpac`.

----

## Determine Your SQL Server Installations

You can run the following PowerShell command from the terminal to list your running instance(s) of SQL Server.

```ps
Get-Service | ?{ $_.Name -like "MSSQL*" }
```

If you have SQL Server installed, you should see something similar to the following (I'm just showing the database instances here):

```
Status   Name               DisplayName
------   ----               -----------
Running  MSSQL$SQLEXPRESS   SQL Server (SQLEXPRESS)
Running  MSSQLSERVER        SQL Server (MSSQLSERVER)
```

From this list, I can see that I have two SQL Server instances running on my machine. The local machine can be referred to by the dot (`.`) alias.

- **`.`** - The local, default installation (identified just by my computer name)
- **`./SQLEXPRESS`** - A named instance on my local machine
