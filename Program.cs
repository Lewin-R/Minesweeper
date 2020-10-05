using System;

namespace Minesweeper
{
    internal class Program
    {
        //Input
        public static Grid getGridSize()
        {
            bool i = false;
            bool validater = false;

            int _height = 0;
            int _width = 0;

            while (i == false)
            {
                try
                {
                    while (validater == false)
                    {
                        Console.WriteLine("Geben Sie die Höhe an, muss zwischen 8 und 26 sein.");
                        _height = Int32.Parse(Console.ReadLine());
                        if (_height >= 8 && _height <= 26)
                        {
                            validater = true;
                        }

                        Console.Clear();
                        Console.WriteLine(
                            "Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
                catch (Exception x) //fängt bestimmten Fehler ab, exception fängt alles ab
                {
                    Console.WriteLine("Geben Sie eine Zahl an");
                }

                validater = false;
                Console.Clear();
                try
                {
                    while (validater == false)
                    {
                        Console.WriteLine("Geben Sie die Breite an, muss zwischen 8 und 26 sein.");
                        _width = Int32.Parse(Console.ReadLine());
                        if (_width >= 8 && _width <= 26)
                        {
                            validater = true;
                        }

                        Console.Clear();
                        Console.WriteLine("Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("Geben Sie eine Zahl an");
                }
            }
            return new Grid(_height, _width);
        }

        private static void Main(string[] args)
        {

        }
    }
}