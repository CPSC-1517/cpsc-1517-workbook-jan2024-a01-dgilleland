using System;
using static System.Console; // Allows me to directly use static members of the Console class

namespace Topic.A
{
    public class AM_Driver
    {
        public static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                WriteLine(AnsweringMachine.Answer(args[0]));
                Beep();
                if(args.Length > 1)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"(message) {args[1]}");
                    ResetColor();
                }
            }
            else
            {
                WriteLine(AnsweringMachine.Answer());
                Beep();
            }
        }
    }
}