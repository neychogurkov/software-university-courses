using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int GetDaysDifference(string firstDate, string secondDate)
        {
            int daysDiff = (DateTime.Parse(firstDate) - DateTime.Parse(secondDate)).Days;
            return Math.Abs(daysDiff);
        }
    }
}
