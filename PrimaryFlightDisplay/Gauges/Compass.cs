using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrimaryFlightDisplay.Gauges
{
    internal class Compass : VerticalTape
    {
        /// <summary>
        /// Brush.</summary>
        private Brush drawingBrush = new SolidBrush(Color.Gray);

        public Compass()
            : base()
        {
            this.MinimumValue = 0;
            this.MaximumValue = 360;
            this.MajorGraduation = 30;
            this.NeverExceedValue = 0;
        }

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected override void NewEnvelope()
        {
            int xCenter = (envelope.Right + envelope.Left) / 2;

            currentValueIndicator = new Point(xCenter - 10, envelope.Top - 22);

            currentIndicator = new Point[] { 
                    new Point(xCenter, envelope.Top),
                    new Point(xCenter - 5, envelope.Top - 5),
                    new Point(xCenter - 20, envelope.Top - 5),
                    new Point(xCenter - 20, envelope.Top - 25),
                    new Point(xCenter + 20, envelope.Top - 25),
                    new Point(xCenter + 20, envelope.Top - 5),
                    new Point(xCenter + 5, envelope.Top - 5)
                };
        }

        /// <summary>
        /// Draw Major Graduation.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawMajorGraduation(Graphics g, long graduationValue, int pixelCoordinate)
        {
            // Major Graduation
            int gradFrom = envelope.Top;
            int gradTo = envelope.Top + 15;

            if (graduationValue < minimumValue || graduationValue > maximumValue)
            {
                graduationValue = (maximumValue + graduationValue) % maximumValue;
            }

            string tick = graduationValue.ToString();

            if (graduationValue == 0 || graduationValue == 360)
                tick = "N";
            if (graduationValue == 90)
                tick = "E";
            if (graduationValue == 180)
                tick = "S";
            if (graduationValue == 270)
                tick = "W";

            g.DrawLine(drawingPen, pixelCoordinate, gradFrom, pixelCoordinate, gradTo);
            g.DrawString(tick, SystemFonts.DefaultFont, Brushes.White, pixelCoordinate - 8, gradTo + 4);

            // Minor Graduation
            gradFrom = envelope.Top;
            gradTo = envelope.Top + 10;
            int xSubGrad = pixelCoordinate + (pixelPerGraduation / 2);

            g.DrawLine(drawingPen, xSubGrad, gradFrom, xSubGrad, gradTo);
        }

        /// <summary>
        /// Draw Current Value Indicator.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawCurrentValueIndicator(Graphics g)
        {
            string degree = currentValue.ToString() + "°";

            g.FillPolygon(Brushes.Black, currentIndicator);
            g.DrawPolygon(drawingPen, currentIndicator);
            g.DrawString(degree, SystemFonts.DefaultFont, Brushes.White, currentValueIndicator);
        }

        /// <summary>
        /// Draw Tape.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawTape(Graphics g)
        {
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                g.SetClip(envelope);

                g.FillRectangle(alphaBrush, envelope);
                g.DrawRectangle(drawingPen, envelope);

                // Previous major graduation value next to currentValue.
                long majorGraduationValue = (currentValue / majorGraduation) * majorGraduation;

                // First major graduation value on screen
                long majorGraduationBottomInterval = envelope.Width / pixelPerGraduation / 2 * majorGraduation;

                // Current value pixel offset
                long currentValuePixelOffset = (long)(((float)(currentValue % majorGraduation) / (float)majorGraduation) * pixelPerGraduation);

                int drawAreaLenght = (int)(majorGraduationBottomInterval * 2 * pixelPerGraduation / majorGraduation); // In Pixels

                int drawAreaPadding = (envelope.Width - drawAreaLenght) / 2;

                int pixelCoordinateBegin = envelope.Left + drawAreaPadding - (int)currentValuePixelOffset;

                for (long itemValue = (majorGraduationValue - majorGraduationBottomInterval);
                    itemValue <= (majorGraduationValue + majorGraduationBottomInterval + majorGraduation);
                    itemValue += majorGraduation)
                {
                    DrawMajorGraduation(g, itemValue, pixelCoordinateBegin);
                    pixelCoordinateBegin += pixelPerGraduation;
                }

                DrawTape(g);

                g.ResetClip();

                DrawCurrentValueIndicator(g);

            }
        }

        /// <summary>
        /// Dispose.</summary>
        public override void Dispose()
        {
            if (drawingBrush != null)
            {
                drawingBrush.Dispose();
                drawingBrush = null;
            }

            base.Dispose();
        }
    }
}
