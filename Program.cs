using System;

namespace Minesweeper
{
    internal class Program
    {
        internal static bool GameOver;
        internal static int i = 1;
        private static void Main(string[] args)
        {
            //get the grid sizes form the User
            Input.grid = Input.GetGridSize();
            Timer.SetTimer();
            int selection = 0;
            while (!GameOver)
            {


                Input.grid.GridDisplay();

                //Winnin Sequence
                if (Input.grid.MineCount == 0)
                {
                    Console.WriteLine("Congratulation, you have won!");
                    Timer.EndTimer();
                    return;
                }

                selection = Input.PlayerSelection();
                Field f = Input.GetCoordinates();


                switch (selection)
                {
                    case 1:
                        GameOver = f.UncoverField();
                        break;

                    case 2:
                       
                        f.FlaggField();
                        break;

                    case 3:
                       
                        f.UnflaggField();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Game Over");
        }
    }
}