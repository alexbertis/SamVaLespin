namespace SamVaLespin.Services
{
    public class TimeService
    {
        private TimeZoneInfo _timeZone;
        public TimeService()
        {
            Initialise();
        }

        private void Initialise()
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");
        }

        public DateTime GetSamValenTime() => TimeZoneInfo.ConvertTime(DateTime.UtcNow, _timeZone);
    }
}
