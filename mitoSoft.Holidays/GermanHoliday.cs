using System;

namespace mitoSoft.Holidays.Models
{
    public class GermanHoliday : IComparable<GermanHoliday>
    {
        public GermanHoliday(bool isFix, DateTime datum, string name, params States[] states)
        {
            this.IsFix = isFix;
            this.Date = datum;
            this.Name = name;
            this.States = states;
        }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public string Name { get; }

        public States[] States { get; }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public bool IsFix { get; }

        public int CompareTo(GermanHoliday other)
        {
            return this.Date.Date.CompareTo(other.Date.Date);
        }
    }
}