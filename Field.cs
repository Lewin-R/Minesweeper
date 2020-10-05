using System;

namespace Minesweeper
{
    internal class Field
    {
        internal bool IsBomb { get; set; } = false;
        internal Field Right { get; set; }
        internal Field Left { get; set; }

        //creates new Field
        public Field()
        {
            //Random for the Mines
            var random = new Random();
            int randomnumber = random.Next(1, 100);

            if (randomnumber < 16)
            {
                IsBomb = true;
            }
        }
    }
}