# Tabular Output in the Terminal

> The following is a discussion with AI.

![Me](./images/Copilot-Me.png)

Is there a C# equivalent for the JavaScript `console.table()` method?

![AI](./images/Copilot-AI.png)

Certainly! In C#, there isn't a direct equivalent to JavaScript's `console.table()` method, but you can achieve similar tabular output in the console using other techniques.

1. **String Formatting**:
   You can use `String.Format` with alignment values to create formatted rows. For example:
   ```csharp
   string formattedRow = String.Format("|{0,-10}|{1,-10}|{2,-10}|{3,-10}|", arg0, arg1, arg2, arg3);
   ```
   Adjust the column widths and alignment as needed¹.

2. **Manual Table Drawing**:
   If you want more control over the table layout, you can manually draw the table using `Console.WriteLine` and dashes for borders. Here's a simple example:
   ```csharp
   static int tableWidth = 73;

   static void Main(string[] args)
   {
       Console.Clear();
       PrintLine();
       PrintRow("Column 1", "Column 2", "Column 3", "Column 4");
       PrintLine();
       PrintRow("", "", "", "");
       PrintRow("", "", "", "");
       PrintLine();
       Console.ReadLine();
   }

   static void PrintLine()
   {
       Console.WriteLine(new string('-', tableWidth));
   }

   static void PrintRow(params string[] columns)
   {
       int width = (tableWidth - columns.Length) / columns.Length;
       foreach (string column in columns)
       {
           Console.Write("|");
           Console.Write(column.PadRight(width));
       }
       Console.WriteLine("|");
   }
   ```
   Adjust the `tableWidth` and column data as needed¹.

Remember that these approaches are not as dynamic as `console.table()` in JavaScript, but they allow you to display tabular data in a console application. Choose the method that best suits your requirements! 🚀

Source: Conversation with Bing, 2024-03-15

(1) How To: Best way to draw table in console app (C#). https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c.

(2) how to pass c# datatable to a javascript function. https://stackoverflow.com/questions/19567990/how-to-pass-c-sharp-datatable-to-a-javascript-function.

(3) JavaScript equivalents of some common C# LINQ methods. To help me .... https://gist.github.com/DanDiplo/30528387da41332ff22b.

(4) Is there an equivalent to JavaScript parseInt in C#?. https://stackoverflow.com/questions/975455/is-there-an-equivalent-to-javascript-parseint-in-c.

(5) github.com. https://github.com/zmqgeek/code/tree/c47c70da43d87e3e60a3bfb921985ad3e73d481c/code1%2F55218-856918-0.cs.

(6) github.com. https://github.com/kannan-ar/Code-Samples/tree/9718e894edc46b07742649585375dd09d5cad178/SalesSystem%2FSalesSimulator%2FConsoleLogger.cs.

(7) github.com. https://github.com/shendongnian/download4/tree/e45352911534dfb757cba4d0074eec312760536f/code1%2F55220-856918-213966368-2.cs.

----

![Me](./images/Copilot-Me.png)



![AI](./images/Copilot-AI.png)

