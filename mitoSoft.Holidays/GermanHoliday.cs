using System;

namespace mitoSoft.Holidays.Models
{
    public class GermanHoliday : IComparable<GermanHoliday>
    {
        public GermanHoliday(bool isFix, DateTime datum, string name, params Provinces[] federalProvinces)
        {
            this.IsFix = isFix;
            this.Date = datum;
            this.Name = name;
            this.FederalProvinces = federalProvinces;
        }

        /// <summary>
        /// Beschreibung: 
        /// </summary>
        public string Name { get; }

        public Provinces[] FederalProvinces { get; }

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