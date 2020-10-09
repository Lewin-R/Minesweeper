using System;

namespace Minesweeper
{
    internal class Grid
    {
        internal int MineCount;
        public Field topLeftField;

        public Grid(int height, int width)
        {
            GHeight = height;
            GWidth = width;

            //Initialize first of row
            Field firstOfRow = new Field();

            for (int i = 0; i < GHeight; i++) //to get every column
            {
                Field firstOfPreviousRow = firstOfRow;
                firstOfRow = new Field();

                //to safe the start
                if (i == 0)
                {
                    topLeftField = firstOfRow;
                }

                Field currenField = null; //shouldn't be initialized

                for (int j = 0; j < GWidth; j++) //to get every row
                {
                    if (j == 0)
                    {
                        currenField = firstOfRow;
                    }

                    Field initField = new Field();

                    //to  make the connection between left and right
                    if (j != width)
                    {
                        currenField.Right = initField;
                        initField.Left = currenField;
                    }

                    //to check if i = 0 it does set the
                    if (i != 0)
                    {
                        currenField.Top = firstOfPreviousRow;
                        firstOfPreviousRow.Bottom = currenField;
                    }

                    //to get the count of mines
                    if (currenField.IsMine)
                    {
                        MineCount++;
                    }

                    currenField = initField;

                    if (i != 0) { firstOfPreviousRow = firstOfPreviousRow.Right; }
                }
            }
        }

        private int GHeight { get; }
        private int GWidth { get; }

        public void GridDisplay()
        {
            //Output of the grid
            Field yAxis = topLeftField;
            Field xAxis = topLeftField;
            int counter = 1;

            Console.Clear();

            PrintHeaderOfTable();

            while (xAxis != null)
            {
                PrintRowSelector(counter);
                yAxis = xAxis;

                while (yAxis.Right != null)
                {
                    yAxis.Print();
                    //Console.Write(yAxis.ChangeSymbols() + " ");
                    //Console.ResetColor();
                    Console.Write(" ");
                    yAxis = yAxis.Right;
                }

                Console.WriteLine();

                xAxis = xAxis.Bottom;
                counter++;
            }
        }

        private void PrintRowSelector(int counter)
        {
            Console.Write(counter);
            if (counter < 10)
            {
                Console.Write(" ");
            }

            Console.Write(" ¦¦ ");

        }

        private void PrintHeaderOfTable()
        {
            //Create the alphabet
            Console.Write("      ");
            for (int i = 0; i < GWidth; i++)
            {
                Console.Write((char)(i + 'A') + " ");
            }

            Console.WriteLine();
            Console.Write("   ##");

            for (int i = 0; i < GWidth; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
        }

        internal Field FieldSelection(char x, int y) //übergabeparameter
        {
            //get the column
            Field result = topLeftField;

            int xi = x - 65;
            //to get the column
            for (int i = 0; i < xi; i++)
            {
                try
                {
                    result = result.Right;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The entered coordinates don't exist!");
                    Input.GetCoordinates();
                }
            }

            //to get the row
            for (int i = 0; i < y - 1; i++)
            {
                try
                {
                    result = result.Bottom;
                }
                catch (Exception e)
                {
                    Console.WriteLine("The entered coordinates don't exist!");
                    Input.GetCoordinates();
                }
            }

            return result;
        }
    }
}