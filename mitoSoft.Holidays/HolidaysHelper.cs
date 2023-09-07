namespace mitoSoft.Holidays
{
    public static class HolidaysHelper
    {
        /// <summary>
        /// Supported countries: "us", "de"
        /// </summary>
        public static IHolidays GetHolidays(string countryId)
        {
            IHolidays result = null;
            switch (countryId?.ToLowerInvariant())
            {
                case "de":
                    {
                        result = new Germany.Holidays();

                        break;
                    }
                case "us":
                    {
                        result = new UnitedStates.Holidays();

                        break;
                    }
            }

            return result;
        }
    }
}