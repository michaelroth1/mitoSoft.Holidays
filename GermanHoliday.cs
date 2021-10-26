using System;

namespace mitoSoft.homeNet.Holidays.Models
{
    public class GermanHoliday : IComparable<GermanHoliday>
    {
        public GermanHoliday(bool isFix, DateTime datum, string name)
        {
            this.IsFix = isFix;
            this.Date = datum;
            this.Name = name;
        }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public bool IsFix { get; set; }

        public int CompareTo(GermanHoliday other)
        {
            return this.Date.Date.CompareTo(other.Date.Date);
        }
    }
}