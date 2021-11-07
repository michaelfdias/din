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
    }
}
