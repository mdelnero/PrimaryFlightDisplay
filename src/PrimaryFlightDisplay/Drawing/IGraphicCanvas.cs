using System.Drawing;

namespace PrimaryFlightDisplay.Drawing
{
    /// <summary>
    /// Graphic Indicator Interface.
    /// </summary>
    public interface IGraphicCanvas
    {
        /// <summary>
        /// Major Graduation Size in Pixels.</summary>
        int PixelPerGraduation { get; set; }

        /// <summary>
        /// Drawing Envelope.</summary>
        Rectangle DrawingEnvelope { get; }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        void SetDrawingEnvelope(Rectangle envelope);

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void Draw(Graphics g);
    }
}
