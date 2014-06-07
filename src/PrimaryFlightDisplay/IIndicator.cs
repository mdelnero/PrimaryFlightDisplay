
namespace PrimaryFlightDisplay
{
    /// <summary>
    /// Indicator Interface.</summary>
    public interface IIndicator
    {
        /// <summary>
        /// Value.</summary>
        long Value { get; set; }

        /// <summary>
        /// Command Value.</summary>
        long CommandValue { get; set; }

        /// <summary>
        /// Minimum Indicator Value.</summary>
        long MinimumValue { get; set; }

        /// <summary>
        /// Maximum Indicator Value.</summary>
        long MaximumValue { get; set; }

        /// <summary>
        /// Major Scale Graduation.
        /// </summary>
        long MajorScaleGraduation { get; set; }

        /// <summary>
        /// Minor Scale Graduation.
        /// </summary>
        long MinorScaleGraduation { get; set; }
    }
}