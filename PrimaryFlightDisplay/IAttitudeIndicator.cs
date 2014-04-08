
namespace PrimaryFlightDisplay
{
    public interface IAttitudeIndicator
    {
        /// <summary>
        /// Roll Angle.</summary>
        float RollAngle { get; set; }

        /// <summary>
        /// Pitch Angle.</summary>
        float PitchAngle { get; set; }
    }
}
