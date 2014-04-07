using System.Drawing;

namespace PrimaryFlightDisplay
{
    public interface IGraphicGauge : IGraphicControl
    {
        /// <summary>
        /// Gets or Sets the Major Graduation.
        /// </summary>
        long MajorGraduation { get; set; }

        /// <summary>
        /// Gets or Sets the Minor Graduation.
        /// </summary>
        long MinorGraduation { get; set; }

        /// <summary>
        /// Draw Major Graduation.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void DrawMajorGraduation(Graphics g, long graduationValue, int position);

        // <summary>
        /// Draw Current Value Indicator.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void DrawCurrentValueIndicator(Graphics g);

        /// <summary>
        /// Draw Tape.</summary>
        /// <param name="g">Graphics for Drawing</param>
        void DrawTape(Graphics g);
    }
}
