using System;
using System.Drawing;

namespace PrimaryFlightDisplay
{
    internal class Gauge :
        IGauge,
        IGraphicIndicator,
        IDisposable
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
        protected long neverExceedValue = 90;

        /// <summary>
        /// Major Graduation.
        /// </summary>
        protected long majorGraduation = 10;

        /// <summary>
        /// Minor Graduation.
        /// </summary>
        protected long minorGraduation = 5;

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
        /// Gets or Sets the Major Graduation.
        /// </summary>
        public long MajorGraduation
        {
            get
            {
                return majorGraduation;
            }
            set
            {
                majorGraduation = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Minor Graduation.
        /// </summary>
        public long MinorGraduation
        {
            get
            {
                return minorGraduation;
            }
            set
            {
                minorGraduation = value;
            }
        }


        /// <summary>
        /// Gets Drawing Envelope.</summary>
        public Rectangle DrawingEnvelope
        {
            get { return envelope; }
        }

        /// <summary>
        /// Drawing Envelope.</summary>
        protected Rectangle envelope;

        /// <summary>
        /// Size of Major Graduation in Pixels.</summary>
        protected int pixelPerGraduation = 40;
        /// <summary>
        /// Gets or Sets Major Graduation Size in Pixels.</summary>
        public int PixelPerGraduation
        {
            get { return pixelPerGraduation; }
            set { pixelPerGraduation = value; }
        }

        /// <summary>
        /// Class Constructor.</summary>
        public Gauge()
        {
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetDrawingEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            NewEnvelope();
        }

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected virtual void NewEnvelope()
        {
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// Dispose.</summary>
        public virtual void Dispose()
        {
        }
    }
}
