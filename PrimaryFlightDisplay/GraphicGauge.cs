using System.Drawing;
using PrimaryFlightDisplay;

namespace PrimaryFlightDisplay
{
    public class GraphicGauge : Gauge, IGraphicGauge
    {
        /// <summary>
        /// Gauge Increment.
        /// </summary>
        protected long gaugeIncrement = 1;

        /// <summary>
        /// Gets or Sets the Gauge Increment.
        /// </summary>
        public long GaugeIncrement 
        {
            get
            {
                return gaugeIncrement;
            }
            set
            {
                gaugeIncrement = value;
            }
        }

        /// <summary>
        /// Parent Graphics Width.</summary>
        protected int parentWidth;

        /// <summary>
        /// Parent Graphics Heigth.</summary>
        protected int parentHeigth;

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
        /// Informs Parent Drawing size.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        public virtual void SetParentSize(int parentWidth, int parentHeigth)
        {
            this.parentWidth = parentWidth;
            this.parentHeigth = parentHeigth;

            envelope = MakeEnvelope();
        }

        /// <summary>
        /// Makes the Drawing Envelope.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        /// <returns>The Drawing Envelope.</returns>
        public virtual Rectangle MakeEnvelope()
        {
            return new Rectangle(0, 0, parentWidth, parentHeigth);
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
        }
    }
}