﻿using System;

namespace Minesweeper
{
    internal class Program
    {
        //Input
        public static Grid getGridSize()
        {
            bool i = false;
            bool validater = false;
            bool validater2 = false;

            int _height = 0;
            int _width = 0;

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
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
            }
            catch (Exception x) //fängt bestimmten Fehler ab, exception fängt alles ab
            {
                Console.WriteLine("Geben Sie eine Zahl an");
            }

            try
            {
                while (validater2 == false)
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
                        Console.WriteLine("Geben Sie eine Zahl an, die grösser/gleich 8 und kleiner/gleich 26 ist!");
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Geben Sie eine Zahl an");
            }

            return new Grid(_height, _width);
        }

        private void getCoordinates()
        {
        }

        private static void Main(string[] args)
        {
            //get the grid sizes form the User
            var g1 = getGridSize();
            g1.GridDisplay();
        }
    }
}