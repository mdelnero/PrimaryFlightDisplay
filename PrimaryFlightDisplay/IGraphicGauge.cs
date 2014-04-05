using System.Drawing;

namespace PrimaryFlightDisplay
{
    public interface IGraphicGauge
    {
        /// <summary>
        /// Gets or Sets the Gauge Increment.
        /// </summary>
        long GaugeIncrement { get; set; }

        /// <summary>
        /// Informs Parent Drawing size.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        void SetParentSize(int parentWidth, int parentHeigth);

        /// <summary>
        /// Makes the Drawing Envelope.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        /// <returns>The Drawing Envelope.</returns>
        Rectangle MakeEnvelope();

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void Draw(Graphics g);
    }
}
