namespace CountdownTest;

using System;
using Countdown;
using NUnit.Framework;

public class CountdownTests
{
    [Test]
    public void PastDate_ReturnsFullVacation()
    {
        var countdown = new CountdownTimer(DateTime.Today.AddDays(-1));
        Assert.That(countdown.HowMuchLeft(), Is.EqualTo("Vacation!"));
    }

    [Test]
    public void Today_ReturnsFullVacation()
    {
        var countdown = new CountdownTimer(DateTime.Today);
        Assert.That(countdown.HowMuchLeft(), Is.EqualTo("Vacation!"));
    }

    [Test]
    public void OneWorkdayLeft_ReturnsAcation()
    {
        var target = GetFutureWorkday(DateTime.Today, 1);
        var countdown = new CountdownTimer(target);
        Assert.That(countdown.HowMuchLeft(), Is.EqualTo("acation!"));
    }

    [Test]
    public void TwoWorkdaysLeft_ReturnsCation()
    {
        var target = GetFutureWorkday(DateTime.Today, 2);
        var countdown = new CountdownTimer(target);
        Assert.That(countdown.HowMuchLeft(), Is.EqualTo("cation!"));
    }

    [Test]
    public void NineWorkdaysLeft_ReturnsStillFarAway()
    {
        var target = GetFutureWorkday(DateTime.Today, 9);
        var countdown = new CountdownTimer(target);
        Assert.That(countdown.HowMuchLeft(), Is.EqualTo("That's still far away!"));
    }

    private static DateTime GetFutureWorkday(DateTime start, int workdaysToAdd)
    {
        var date = start;
        int count = 0;

        while (count < workdaysToAdd)
        {
            date = date.AddDays(1);
            if (date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday)
            {
                count++;
            }
        }

        return date;
    }
}