using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace Topic
{
    class Program
    {
        #region Entry Point for Topic Demos
        static void Main(string[] args)
        {
            try
            {
                Program app = new(args); // Note the new C# 9.0 way to instantiate the class - much cleaner!
                app.Run();
            }
            finally
            {
                ResetColor();
            }
        }
        #endregion

        #region The Driver of drivers
        public Program(string[] args)
        {
            Args = args;
            var types = this.GetType().Assembly.GetTypes();
            var methods = from type in types
                          where type.IsClass && type != this.GetType()
                          from method in type.GetRuntimeMethods()
                          where method.IsStatic && 
                          method.Name.Equals(nameof(Main),StringComparison.InvariantCultureIgnoreCase)
                          select new
                          {
                              type.FullName,
                              method
                          };
            Drivers = methods.ToDictionary(a => a.FullName, b => b.method);
        }
        string[] Args;
        Dictionary<string, MethodInfo> Drivers = new ();
        public void Run()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"There are {Drivers.Count} drivers:");
            ResetColor();
            foreach(var item in Drivers)
            {
                ForegroundColor = ConsoleColor.Cyan;
                Write("( ) ");
                ResetColor();
                WriteLine(item.Key);
            }
            int index = GetSelection(Drivers.Count);
            var selected = Drivers.ElementAt(index);
            ForegroundColor = ConsoleColor.Yellow;
            Write($"Running your selection: ");
            ResetColor();
            WriteLine(selected.Key);
            WriteLine();

            selected.Value.Invoke(null, new object[] {Args});
        }

        int GetSelection(int count)
        {
            ForegroundColor = ConsoleColor.Green;
            Write("Select a driver. Use the arrow keys to navigate and the space key to select.");
            ResetColor();
            var currentPosition = GetCursorPosition();
            Console.SetCursorPosition(1, currentPosition.Top - (count));

            int index = 0, min = 0, max = count - 1, selected = -1;
            do
            {
                var key = ReadKey(true);
                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(index > min)
                        {
                            Console.SetCursorPosition(1, GetCursorPosition().Top - 1);
                            index --;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(index < max)
                        {
                            Console.SetCursorPosition(1, GetCursorPosition().Top + 1);
                            index ++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Write("o");
                        selected = index;
                        break;
                }
            }while(selected < 0);
            SetCursorPosition(currentPosition.Left, currentPosition.Top);
            WriteLine();
            return selected;
        }

        #endregion
    }
}
