// See https://aka.ms/new-console-template for more information
using AdHoc;
using Assorted;
using static System.Console;

if (args.Length > 0) // come back to fix this
{
    DemoFraction.Run(args);
}
else
{
    WriteLine("Hello, World!");

    Coin myCoin = new();

    WriteLine($"My coin is showing {myCoin.FaceShowing}");

    var myNumber = 0.1;

    var total = myNumber + myNumber + myNumber;
    WriteLine($"The total is {total}");
    WriteLine($"With Multiplication: {myNumber * 3}");

    ForegroundColor = ConsoleColor.Green;
    Fraction aFraction = new(5, 6);
    WriteLine(aFraction);
    ResetColor();
}