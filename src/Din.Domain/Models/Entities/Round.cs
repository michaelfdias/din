using System;
using Din.Domain.Models.Enumerations;

namespace Din.Domain.Models.Entities
{
    public struct Round
    {
        public int Year { get; set; }
        public Month Month { get; set; }

        public Round(int year, Month month)
        {
            Year = year;
            Month = month;
        }

        public static Round Current()
        {
            var today = DateTime.Now;
            Enum.TryParse(today.Month.ToString(), true, out Month month);
            return new Round(today.Year, month);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var round = (Round)obj;
            return Year == round.Year && Month == round.Month;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Year, Month).GetHashCode();
        }
    }
}
