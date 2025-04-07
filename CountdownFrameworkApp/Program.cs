using System;
using Countdown;

namespace CountdownFrameworkApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var countdown = new CountdownTimer(DateTime.Today.AddDays(7));
            Console.WriteLine("Countdown result: " + countdown.HowMuchLeft());
        }
    }
}