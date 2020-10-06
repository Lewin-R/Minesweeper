namespace Minesweeper
{
    internal class Grid
    {
        private int GHeight { get; }
        private int GWidth { get; }

        public Field topLeftField = null;

        public Grid(int height, int width)
        {
            GHeight = height;
            GWidth = width;

            //Initialize first of row
            var firstOfRow = new Field();

            for (int i = 0; i < GHeight; i++)//to get every column
            {
                var firstOfPreviousRow = firstOfRow;
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

                    var initField = new Field();

                    //to  make the connection between left and right
                    if (j != width - 1)
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

                    currenField = initField;
                    currenField.Output = 1500 + j;

                    if (i != 0) { firstOfPreviousRow = firstOfPreviousRow.Right; } //check ich noch nicht ganz
                }
            }
        }
    }
}