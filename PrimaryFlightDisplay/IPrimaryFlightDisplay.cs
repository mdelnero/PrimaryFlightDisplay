
namespace PrimaryFlightDisplay
{
    /// <summary>
    /// Primary Flight Display Interface.
    /// </summary>
    public interface IPrimaryFlightDisplay
    {
        /// <summary>
        /// Air Speed Tape.</summary>
        IGauge AirSpeed { get; }

        /// <summary>
        /// Altitude Tape.</summary>
        IGauge Altitude { get; }

        /// <summary>
        /// Compass.</summary>
        IGauge Compass { get; }

        /// <summary>
        /// Attitude Indicator.</summary>
        IAttitudeIndicator AttitudeIndicator { get; }
    }
}
