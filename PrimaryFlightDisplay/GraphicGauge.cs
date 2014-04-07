using System.Drawing;
using PrimaryFlightDisplay;

namespace PrimaryFlightDisplay
{
    public class GraphicGauge : Gauge, IGraphicGauge
    {
        /// <summary>
        /// Major Graduation.
        /// </summary>
        protected long majorGraduation = 10;

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
        /// Minor Graduation.
        /// </summary>
        protected long minorGraduation = 1;

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
        /// Drawing Envelope.</summary>
        /// <remarks>The Envelope is prepared every SetSize call.</remarks>
        protected Rectangle envelope;

        /// <summary>
        /// Class Constructor.</summary>
        public GraphicGauge()
            : base()
        {
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
        }

        /// <summary>
        /// Draw Major Graduation.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawMajorGraduation(Graphics g, long graduationValue, int position)
        {
        }

        // <summary>
        /// Draw Current Value Indicator.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawCurrentValueIndicator(Graphics g)
        {
        }

        /// <summary>
        /// Draw Tape.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawTape(Graphics g)
        {
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
        }
    }
}