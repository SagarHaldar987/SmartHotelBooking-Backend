namespace SmartHotelBooking.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }

        public static DateTime ConvertToUtc(DateTime dateTime, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZone);
        }

        public static DateTime ConvertFromUtc(DateTime utcDateTime, string timeZoneId)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
        }
    }
}
