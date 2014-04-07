using System.Drawing;

namespace PrimaryFlightDisplay
{
    public interface IGraphicControl
    {
        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        void SetEnvelope(Rectangle envelope);

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void Draw(Graphics g);
    }
}
