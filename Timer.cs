using System;
using System.Timers;

namespace Minesweeper
{
    public class Timer
    {
        public static System.Timers.Timer stopWatch;
        private static int time;

        internal static void SetTimer()
        {
            // Create a timer with a two second interval.
            stopWatch = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            stopWatch.Elapsed += OnTimedEvent;
            stopWatch.AutoReset = true;
            stopWatch.Enabled = true;
        }


        internal static void EndTimer()
        {
            Console.WriteLine($"\n Your time is: {time}");
            stopWatch.Dispose();
        }
        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            time++;
        }
    }
}
