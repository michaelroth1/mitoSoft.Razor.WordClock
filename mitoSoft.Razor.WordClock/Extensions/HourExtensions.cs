namespace mitoSoft.Razor.WordClock.Extensions
{
    internal static class HourExtensions
    {
        /// <remarks>
        /// Only hours between 1-12 are valid
        /// </remarks>
        public static int GetShortHour(this int hour)
        {
            if (hour < 0 && hour > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            if (hour > 12)
            {
                return hour - 12;
            }
            else
            {
                return hour;
            }
        }
    }
}