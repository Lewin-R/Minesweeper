using System;

namespace Minesweeper
{
    internal class Grid
    {
        private int GHeight { get; }
        private int GWidth { get; }
        public Field topLeftField;

        internal int MineCount;

        public Grid(int height, int width)
        {
            GHeight = height;
            GWidth = width;

            //Initialize first of row
            var firstOfRow = new Field();

            for (int i = 0; i <= GHeight; i++) //to get every column
            {
                var firstOfPreviousRow = firstOfRow;
                firstOfRow = new Field();

                //to safe the start
                if (i == 0)
                {
                    topLeftField = firstOfRow;
                }

                Field currenField = null; //shouldn't be initialized

                for (int j = 0; j <= GWidth; j++) //to get every row
                {
                    if (j == 0)
                    {
                        currenField = firstOfRow;
                    }

                    var initField = new Field();

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

        public void GridDisplay()
        {
            //Output of the grid
            Field yAxis = topLeftField;
            Field xAxis = topLeftField;
            int Counter = 1;

            Console.Clear();

            Console.Write("      ");
            for (int i = 0; i <= GWidth - 1; i++)
            {
                Console.Write(((char)(i + (int)'A') + " "));
            }

            Console.WriteLine();
            Console.Write("   ##");

            for (int i = 0; i <= GWidth - 1; i++)
            {
                Console.Write("--");
            }

            Console.WriteLine();

            while (xAxis.Bottom != null)
            {
                Console.Write(Counter);
                if (Counter < 10) Console.Write(" ");
                Console.Write(" ¦¦ ");

                yAxis = xAxis;

                while (yAxis.Right != null)
                {
                    Console.Write(yAxis.ChangeSymbols() + " ");
                    Console.ResetColor();
                    yAxis = yAxis.Right;
                }
                Console.WriteLine();

                xAxis = xAxis.Bottom;
                Counter++;
            }
        }

        internal Field FieldSelection(char x, int y) //übergabeparameter
        {
            //get the column
            int xi = (int)x - 65;

            
            Field result = topLeftField;

            //to get the column
            for (int i = 0; i < xi; i++)
            {
                result = result.Right;
            }

            //to get the row
            for (int i = 0; i < y-1; i++)
            {
                result = result.Bottom;
            }

            return result;
        }
    }
}