using Countdown;

namespace CountdownNetCore;

class Program
{
    static void Main(string[] args)
    {
        var countdown = new CountdownTimer(DateTime.Today.AddDays(5));
        Console.WriteLine("Countdown result: " + countdown.HowMuchLeft());
    }
}