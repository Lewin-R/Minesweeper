namespace Minesweeper
{
    internal class Grid
    {
        private int GHeight { get; set; }
        private int GWidth { get; set; }

        private Field topLeftField = null;

        public Grid(int height, int width)
        {
            GHeight = height;
            GWidth = width;

            for (int i = 0; i < height; i++)//to get every column
            {
                //Initialize first of row
                var firstOfRow = new Field();

                //to safe the start
                if (i == 0)
                {
                    firstOfRow = topLeftField;
                }

                Field currenField = null; //shouldn't be initialized

                for (int j = 0; j < width; j++) //to get every row
                {
                    if (j == 0)
                    {
                        currenField = firstOfRow;
                    }

                    if (j != width - 1)
                    {
                        var initField = new Field();
                        currenField.Right = initField;
                        initField.Left = currenField;
                    }
                }
            }
        }
    }
}