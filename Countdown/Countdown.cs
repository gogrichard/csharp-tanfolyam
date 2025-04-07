using System;

namespace Countdown
{
    public class CountdownTimer
    {
        private readonly DateTime _targetDate;
        private const string VacationText = "Vacation!";

        public CountdownTimer(DateTime date)
        {
            _targetDate = date.Date;
        }

        public string HowMuchLeft()
        {
            DateTime today = DateTime.Today;

            if (_targetDate <= today)
                return VacationText;

            int workdays = CountWorkdays(today.AddDays(1), _targetDate);

            return workdays >= VacationText.Length
                ? "That's still far away!"
                : VacationText.Substring(workdays);
        }

        private int CountWorkdays(DateTime start, DateTime end)
        {
            int count = 0;
            DateTime current = start;

            while (current <= end)
            {
                if (current.DayOfWeek != DayOfWeek.Saturday &&
                    current.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
                current = current.AddDays(1);
            }

            return count;
        }
    }
}