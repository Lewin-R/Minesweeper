using System;

namespace Minesweeper
{
    internal class Grid
    {
        private int GHeight { get; }
        private int GWidth { get; }



        private Field topLeftField = null;

        public Grid(int height, int width)
        {
            GHeight = height;
            GWidth = width;

            for (int i = 0; i < GHeight; i++)//to get every column
            {
                //Initialize first of row
                var firstOfRow = new Field();

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

                    var initField = new Field();
                    if (j != width - 1)
                    {
                       
                        currenField.Right = initField;
                        initField.Left = currenField;

                    }
                    currenField = initField;
                    
                }
            }
        }
    }
}