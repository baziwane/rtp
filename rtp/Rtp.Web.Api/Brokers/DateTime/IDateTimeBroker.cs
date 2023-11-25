// Purpose: Interface for DateTimeBroker.cs
using System;

namespace Rtp.Web.Api.Brokers.DateTime
{
    public interface IDateTimeBroker
    {
        /// <summary>
        /// Represents a date and time, typically expressed as a coordinated universal time (UTC) offset.
        /// </summary>
        /// <returns>The current date and time.</returns>
        DateTimeOffset GetCurrentDateTime();
    }
}