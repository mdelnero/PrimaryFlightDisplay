using System.Drawing;

namespace PrimaryFlightDisplay.Indicators
{
    /// <summary>
    /// Heading Indicator.</summary>
    public class HeadingIndicator : Indicator, IHeadingIndicator
    {
        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected override void NewDrawingEnvelopeReceived()
        {
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void Draw(Graphics g)
        {

        }
    }
}
