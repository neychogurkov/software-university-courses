using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = DateTime.Parse(firstDate);
            this.SecondDate = DateTime.Parse(secondDate);
        }

        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public int GetDaysDifference()
        {
            string daysDiff = this.FirstDate.Subtract(this.SecondDate).ToString().Split('.')[0];
            return Math.Abs(int.Parse(daysDiff));
        }
    }
}
