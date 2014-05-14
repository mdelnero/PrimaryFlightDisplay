
namespace PrimaryFlightDisplay
{
    /// <summary>
    /// Primary Flight Display Interface.
    /// </summary>
    public interface IPrimaryFlightDisplay
    {
        /// <summary>
        /// Air Speed Indicator.</summary>
        IIndicator AirSpeed { get; }

        /// <summary>
        /// Altitude Indicator.</summary>
        IIndicator Altitude { get; }

        /// <summary>
        /// Heading Indicator.</summary>
        IIndicator Heading { get; }

        /// <summary>
        /// Attitude Indicator.</summary>
        IAttitudeIndicator AttitudeIndicator { get; }
    }
}
