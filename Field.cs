using System;

namespace Minesweeper
{
    internal class Field
    {
        internal bool IsMine = false;
        internal bool IsCovert;
        internal bool IsFlagged;
        internal Field Right { get; set; }
        internal Field Left { get; set; }
        internal Field Top { get; set; }
        internal Field Bottom { get; set; }

        //creates new Field
        public Field()
        {
            IsCovert = true;
            IsFlagged = false;
            //Random for the Mines
            var random = new Random();
            int randomnumber = random.Next(1, 100);

            if (randomnumber < 6)
            {
                IsMine = true;
            }
        }

        //Get the bombs
        internal int getBombsAroundField()
        {
            int MineCounter = 0;

            if (Bottom != null)
            {
                if (Bottom.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Top != null)
            {
                if (Top.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Left != null)
            {
                if (Left.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Right != null)
            {
                if (Right.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Top?.Right != null)
            {
                if (Top.Right.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Top?.Left != null)
            {
                if (Top.Left.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Bottom?.Right != null)
            {
                if (Bottom.Right.IsMine)
                {
                    MineCounter++;
                }
            }

            if (Bottom?.Left != null)
            {
                if (Bottom.Left.IsMine)
                {
                    MineCounter++;
                }
            }

            return MineCounter;
        }

        internal string ChangeSymbols()
        {
            if (IsCovert)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                return "?";
            }

            if (IsFlagged)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "F";
            }

            if (IsMine)
            {
                Console.ResetColor();
                return "B";
            }
            else
            {
                if (getBombsAroundField() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    return "~";
                }
                else
                {
                    return getBombsAroundField().ToString();
                }
            }
        }

        public bool UncoverField()
        {
            if (IsCovert)
            {
                if (IsFlagged)
                {
                    Console.WriteLine("You can't uncover flagged Fields, unflagg it first");
                }
                if (IsMine)
                {
                    return true;
                }
                //Rekursive Funktion
                else
                {
                    IsCovert = false;
                    if (getBombsAroundField() > 0)
                    {
                        return false;
                    }

                    // Die ? sind eine Abfrage, ob sie null ist, wenn ja => uncover
                    Top?.UncoverField();
                    Bottom?.UncoverField();
                    Left?.UncoverField();
                    Right?.UncoverField();

                    //Uncover the vertical Fields
                    Top?.Right?.UncoverField();
                    Top?.Left?.UncoverField();
                    Bottom?.Right?.UncoverField();
                    Bottom?.Left?.UncoverField();
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public void FlaggField()
        {
            if (IsCovert)
            {
                IsFlagged = true;
                IsCovert = false;
                Input.grid.MineCount--;
            }
            else
            {
                Console.WriteLine("You can't flagg fields, that have already been uncovered");
            }
        }

        public void UnflaggField()
        {
            if (IsFlagged)
            {
                IsFlagged = false;
                IsCovert = true;
                Input.grid.MineCount++;
            }
            else
            {
                Console.WriteLine("You can't unflagg unflagged fields");
            }
        }

        public void Print()
        {
            var x = ChangeSymbols();
            Console.Write(x);
            Console.ResetColor();
        }
    }
}