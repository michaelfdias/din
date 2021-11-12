using System;
using Din.Domain.Models.Enumerations;

namespace Din.Domain.Models.Entities
{
    public struct Round : IComparable<Round>
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

        public int CompareTo(Round other)
        {
            return new DateTime(Year, (int)Month, 1)
                .CompareTo(new DateTime(other.Year, (int)other.Month, 1));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return CompareTo((Round)obj) == 0;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Year, Month).GetHashCode();
        }

        public static bool operator ==(Round left, Round right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Round left, Round right)
        {
            return !(left == right);
        }
    }
}
