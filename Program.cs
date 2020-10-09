using System;

namespace Minesweeper
{
    internal class Program
    {
        internal static bool GameOver;
        internal static bool Quit;

        private static void Main(string[] args)
        {
            Console.ResetColor(); 

            Output op = new Output();
            op.PrintMinesweeper();

            //get the grid sizes form the User
            Input.grid = Input.GetGridSize();
            Timer.SetTimer();
            string selection = string.Empty;

            while (!GameOver || !Quit)
            {
                
                Input.grid.GridDisplay();

                //Winnin Sequence
                if (Input.grid.MineCount == 0)
                {
                    op.PrintWon();
                    Timer.EndTimer();
                    return;
                }

                Field f = Input.GetCoordinates();
                selection = Input.PlayerSelection();

                switch (selection)
                {
                    case "1":
                        GameOver = f.UncoverField();
                        break;

                    case "2":

                        f.FlaggField();
                        break;

                    case "3":

                        f.UnflaggField();
                        break;

                    case "q":
                        GameOver = true;
                        Quit = true;
                        return;
                }
            }

            if (Quit != true)
            {
                Console.Clear();
                op.PrintGameOver();
                op.PressAnyButton();
            }
        }
    }
}