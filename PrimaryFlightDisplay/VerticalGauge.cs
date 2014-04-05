using System.Drawing;

namespace PrimaryFlightDisplay
{
    public enum GaugeDockPosition
    {
        DockLeft,
        DockRight
    }

    public class VerticalGauge : GraphicGauge
    {
        /// <summary>
        /// Pen.</summary>
        private readonly Pen drawingPen = new Pen(Brushes.White, 2);

        private readonly float widthPercent = 0.15f;
        private readonly float heightPercent = 0.5f;

        /// <summary>
        /// Dock Position.</summary>
        private GaugeDockPosition dock;

        /// <summary>
        /// Gets or Sets Dock Position.</summary>
        public GaugeDockPosition DockPosition
        {
            get
            {
                return dock;
            }
            set
            {
                dock = value;
            }
        }

        /// <summary>
        /// Vertical Size of Value Increment in Pixels
        /// </summary>
        private const int PixelPerTick = 40;

        /// <summary>
        /// Current Value Text Point.</summary>
        /// <remarks>The Text Point is prepared every SetParentSize call.</remarks>
        private Point currentValueIndicator;

        /// <summary>
        /// Current Value Drawing Indicator.</summary>
        /// <remarks>The Drawing Indicator is prepared every SetParentSize call.</remarks>
        private Point[] currentIndicator;

        public VerticalGauge()
            : base()
        {
            dock = GaugeDockPosition.DockLeft;
        }

        /// <summary>
        /// Informs Parent Drawing size.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        public override void SetParentSize(int parentWidth, int parentHeigth)
        {
            base.SetParentSize(parentWidth, parentHeigth);
            PrepareDrawingElements();
        }

        /// <summary>
        /// Makes the Drawing Envelope.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        /// <returns>The Drawing Envelope.</returns>
        public override Rectangle MakeEnvelope()
        {
            int width = (int)(parentWidth * widthPercent);
            int heigth = (int)(parentHeigth * heightPercent);
            int top = (parentHeigth - heigth) / 2;
            int left = dock == GaugeDockPosition.DockLeft ? 0 : parentWidth - width;

            return new Rectangle(left, top, width, heigth);
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                //g.DrawString("METER", SystemFonts.DefaultFont, Brushes.White, envelope.Left, envelope.Top);

                g.SetClip(envelope);

                // Border
                g.DrawRectangle(drawingPen, envelope);

                // Scale
                long tickDivision = (currentValue / gaugeIncrement) * gaugeIncrement;
                long tickDivisionMod = (long)(((float)(currentValue % gaugeIncrement) / (float)gaugeIncrement) * PixelPerTick);
                long halfTickCount = envelope.Height / PixelPerTick / 2 * gaugeIncrement;

                int drawAreaHeigth = (int)(halfTickCount * 2 * PixelPerTick / gaugeIncrement);
                int tickVerticalPad = (envelope.Height - drawAreaHeigth) / 2;
                int yPixelPos = envelope.Bottom - tickVerticalPad + (int)tickDivisionMod;

                for (long itemValue = (tickDivision - halfTickCount);
                    itemValue <= (tickDivision + halfTickCount + gaugeIncrement);
                    itemValue += gaugeIncrement)
                {
                    if (itemValue >= minimumValue && itemValue <= maximumValue)
                    {
                        g.DrawLine(drawingPen, envelope.Left, yPixelPos, envelope.Left + 10, yPixelPos);
                        g.DrawString(itemValue.ToString(), SystemFonts.DefaultFont, Brushes.White, envelope.Left + 20, yPixelPos - 6);

                        // Subdivision
                        if (itemValue < maximumValue)
                            g.DrawLine(drawingPen, envelope.Left, yPixelPos - (PixelPerTick / 2), envelope.Left + 5, yPixelPos - (PixelPerTick / 2));
                    }

                    yPixelPos -= PixelPerTick;
                }

                // Current Value
                g.FillPolygon(Brushes.Black, currentIndicator);
                g.DrawPolygon(drawingPen, currentIndicator);
                g.DrawString(currentValue.ToString(), SystemFonts.DefaultFont, Brushes.White, currentValueIndicator);

                g.ResetClip();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrepareDrawingElements()
        {
            int yCenter = (envelope.Top + envelope.Bottom) / 2;

            currentValueIndicator = new Point(envelope.Left + 25, yCenter-6);

            currentIndicator = new Point[] { 
                        new Point(envelope.Left + 10, yCenter) ,
                        new Point(envelope.Left + 20, yCenter - 10) ,
                        new Point(envelope.Right, yCenter - 10) ,
                        new Point(envelope.Right, yCenter + 10) ,
                        new Point(envelope.Left + 20, yCenter + 10)
                    };
        }

    }
}
