using System;
using System.Text.RegularExpressions;


namespace Minesweeper
{
    class Input
    {
        public static Grid grid;
        public static bool Quit;

        //Input
        public static Grid GetGridSize()
        {
            bool i = false;
            bool validater = false;
            bool validater2 = false;

            int _height = 0;
            int _width = 0;


            while (!validater)
            {
                try
                {
                    Console.WriteLine("Geben Sie die Höhe an, muss zwischen 8 und 26 sein.");
                    _height = Int32.Parse(Console.ReadLine());
                    if (_height >= 8 && _height <= 26)
                    {
                        validater = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
                catch (Exception x) //fängt bestimmten Fehler ab, exception fängt alles ab
                {
                    Console.Clear();
                    Console.WriteLine("Geben Sie eine Zahl an");
                }
            }

            while (!validater2)
            {
                try
                {
                    Console.WriteLine("Geben Sie die Breite an, muss zwischen 8 und 26 sein.");
                    _width = Int32.Parse(Console.ReadLine());
                    if (_width >= 8 && _width <= 26)
                    {
                        validater2 = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
                catch (Exception x)
                {
                    Console.Clear();
                    Console.WriteLine("Geben Sie eine Zahl an");
                }
            }
            return new Grid(_height, _width);
        }

        //Get user Input and convert it
        public static Field GetCoordinates()
        {
            string input = string.Empty;
            string x = string.Empty;
            string y = string.Empty;

            //! Regex machen!!!!

            while (!Regex.IsMatch(x, @"^[a-zA-Z]+$") || !Regex.IsMatch(y, "^[0-9]+$"))
            {
                Console.WriteLine("Geben Sie die Koordinaten für ein Feld ein (z.B. A6): ");
                input = Console.ReadLine();

                while (( x.Length < 2 && x.Length >2) || (y.Length <1 && y.Length>2))
                {
                    Console.WriteLine("Geben Sie eine richtige Koordinate an! (z.B. A6) ");
                    input = Console.ReadLine();
                }
                x = input.Substring(0, 1).ToUpper();
                y = input.Substring(1, input.Length - 1);
            }
            //Substring subdivides Strings into those, witch are defined //Input.lenght-1 to get the numbers even when they're two digitized

            return grid.FieldSelection(Char.Parse(x), Int32.Parse(y)); //FieldSelection wird gerade auchnoch aufgerufen, so  wird dann ein Field ausgegeben.
        }

        internal static int PlayerSelection()
        {
            int input = 0;
            bool Validator = false;

            while (!Validator)
            {
                try
                {
                    Console.WriteLine("Was möchten Sie tun?");
                    Console.WriteLine("(1) Feld aufdecken");
                    Console.WriteLine("(2) Flag Feld");
                    Console.WriteLine("(3) Unflag Feld");
                    var i = Console.ReadLine();
                    
                        input = Int32.Parse(i);
                        Validator = true;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Pleas enter a number, witch is shown above!");
                }
            }

            return input;
        }
    }
}
