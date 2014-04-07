
namespace PrimaryFlightDisplay
{
    public class Gauge : IGauge
    {
        /// <summary>
        /// Gauge Value.</summary>
        protected long currentValue = 0;

        /// <summary>
        /// Minimum Gauge Value.</summary>
        protected long minimumValue = 0;

        /// <summary>
        /// Maximum Gauge Value.</summary>
        protected long maximumValue = 100;

        /// <summary>
        /// Never Exceed Value.</summary>
        protected long neverExceedValue = 100;

        /// <summary>
        /// Gets or Sets Gauge Value.</summary>
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
        /// Gets or Sets Minimum Gauge Value.</summary>
        public virtual long MinimumValue
        {
            get { return minimumValue; }
            set { minimumValue = value; }
        }

        /// <summary>
        /// Gets or Sets Maximum Gauge Value.</summary>
        public virtual long MaximumValue
        {
            get { return maximumValue; }
            set { maximumValue = value; }
        }

        /// <summary>
        /// Never Exceed Value.</summary>
        public virtual long NeverExceedValue
        {
            get { return neverExceedValue; }
            set { neverExceedValue = value; }
        }

        /// <summary>
        /// Class Constructor.</summary>
        public Gauge()
        {
        }
    }
}
