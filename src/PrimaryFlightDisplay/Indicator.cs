
namespace PrimaryFlightDisplay
{
    /// <summary>
    /// Base Indicator.</summary>
    public abstract class Indicator : 
        GraphicIndicator, 
        IIndicator
    {
        /// <summary>
        /// Value.</summary>
        private long currentValue;

        /// <summary>
        /// Command Value.</summary>
        private long commandValue;

        /// <summary>
        /// Minimum Indicator Value.</summary>
        private long minimumValue = 0;

        /// <summary>
        /// Maximum Indicator Value.</summary>
        private long maximumValue = 100;

        /// <summary>
        /// Major Scale Graduation.
        /// </summary>
        private long majorScaleGraduation = 10;

        /// <summary>
        /// Minor Scale Graduation.
        /// </summary>
        private long minorScaleGraduation = 5;

        /// <summary>
        /// Gets or Sets Value.</summary>
        public long Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                if (value > maximumValue)
                    currentValue = maximumValue;
                else if (value < minimumValue)
                    currentValue = minimumValue;
                else
                    currentValue = value;
            }
        }

        /// <summary>
        /// Gets or Sets Command Value.</summary>
        public long CommandValue
        {
            get { return commandValue; }
            set { commandValue = value; }
        }

        /// <summary>
        /// Gets or Sets Minimum Indicator Value.</summary>
        public long MinimumValue
        {
            get { return minimumValue; }
            set { minimumValue = value; }
        }

        /// <summary>
        /// Gets or Sets Maximum Indicator Value.</summary>
        public long MaximumValue
        {
            get { return maximumValue; }
            set { maximumValue = value; }
        }

        /// <summary>
        /// Gets or Sets the Major Scale Graduation.
        /// </summary>
        public long MajorScaleGraduation
        {
            get
            {
                return majorScaleGraduation;
            }
            set
            {
                majorScaleGraduation = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Minor Scale Graduation.
        /// </summary>
        public long MinorScaleGraduation
        {
            get
            {
                return minorScaleGraduation;
            }
            set
            {
                minorScaleGraduation = value;
            }
        }
    }
}
