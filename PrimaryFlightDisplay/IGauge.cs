
namespace PrimaryFlightDisplay
{
    public interface IGauge
    {
        /// <summary>
        /// Gauge Value.</summary>
        long Value { get; set; }

        /// <summary>
        /// Minimum Gauge Value.</summary>
        long MinimumValue { get; set; }

        /// <summary>
        /// Maximum Gauge Value.</summary>
        long MaximumValue { get; set; }

        /// <summary>
        /// Never Exceed Value.</summary>
        long NeverExceedValue { get; set; }
    }
}
