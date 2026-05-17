namespace Clinic_Management_API.Helpers
{
    public static class DateTimeHelper
    {
        private static readonly TimeZoneInfo EgyptTimeZone =
        TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
       
        // 🟢 من UTC → مصر (للعرض في API)
        public static DateTime ToEgyptTime(DateTime utcDate)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDate, EgyptTimeZone);
        }

        // 🟢 من مصر → UTC (وقت الحفظ في الداتا بيز)
        public static DateTime ToUtc(DateTime egyptDate)
        {
            egyptDate = DateTime.SpecifyKind(egyptDate, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeToUtc(egyptDate, EgyptTimeZone);
        }
    }
}
