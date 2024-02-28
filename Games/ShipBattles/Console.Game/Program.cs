// See https://aka.ms/new-console-template for more information
using Dumpify;
using System.ComponentModel.DataAnnotations;
using static System.Console;

Splash();
Concept();

return 0;
/* ^^ --  End of the Main method  -- ^^ */
//////////////////////////////////////////
/* vv -- Methods and Static Types -- vv */

void Splash()
{
    Clear();
    WriteLine("Ship Battles!");
    WriteLine("=============");
    WriteLine("Plays a game of Ship Battles between two players. Game is played in an interactive mode.");
    WriteLine();
    WriteLine("Usage:\tplay \"Player Won\" \"Player Too\"");
    WriteLine();
    ResetColor();
}

void Concept()
{
    char[,] grid = new char[10,10];
    // Initialize
    for(int row = 0; row < 10; row++)
        for(int col = 0; col < 10; col++)
            grid[row,col] = Random.Shared.Next(10) switch
            {
                < 7 => ' ',
                >= 7 and < 9 => '-',
                _   => Random.Shared.Next(5) switch
                {
                    < 4 => '-',
                    _ => 'H'
                }
            };

    grid.Dump();
}

