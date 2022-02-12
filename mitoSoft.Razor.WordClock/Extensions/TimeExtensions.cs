namespace mitoSoft.Razor.WordClock.Extensions
{
    internal static class TimeExtensions
    {
        public static int RoundMinutes(this int minutes)
        {
            return minutes - (minutes % 5);
        }

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