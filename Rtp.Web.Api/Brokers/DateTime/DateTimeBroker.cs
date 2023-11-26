// Purpose: To provide a broker for the current date and time.

namespace Rtp.Web.Api.Brokers.DateTime
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() => 
            DateTimeOffset.UtcNow;
    }
}