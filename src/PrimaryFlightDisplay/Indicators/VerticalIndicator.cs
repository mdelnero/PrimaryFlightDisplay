using System;
using System.Drawing;

namespace PrimaryFlightDisplay.Indicators
{
    public enum IndicatorOrientation
    {
        Left,
        Right
    }

    /// <summary>
    /// Vertical Indicator.</summary>
    public class VerticalIndicator :
        Indicator
    {
        #region Graphics

        /// <summary>
        /// Primary Pen.</summary>
        protected Pen primaryPen = new Pen(Brushes.White, 2);

        /// <summary>
        /// Background Brush.</summary>
        protected Brush backgroundBrush = new SolidBrush(Color.FromArgb(127, 127, 127, 127));

        /// <summary>
        /// Current Value Font.</summary>
        Font fontCurrentValue = new Font("Arial", 12, FontStyle.Bold);

        #endregion

        /// <summary>
        /// Indicator Orientation.</summary>
        private IndicatorOrientation orientation = IndicatorOrientation.Left;

        /// <summary>
        /// Gets or Sets Orientation.</summary>
        public IndicatorOrientation Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }

        /// <summary>
        /// Current Value Text Position.</summary>
        protected Point currentValueTextPosition;

        /// <summary>
        /// Current Value Drawing Indicator.</summary>
        protected Point[] currentValueIndicator;

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected override void NewDrawingEnvelopeReceived()
        {
            int yCenter = envelope.Top + envelopeCenter.Y;

            int heigth = 15;
            int width = 8;

            if (orientation == IndicatorOrientation.Right)
            {
                currentValueTextPosition = new Point(envelope.Left + 24, yCenter - 8);

                currentValueIndicator = new Point[] { 
                        new Point(envelope.Left + 10, yCenter),
                        new Point(envelope.Left + 20, yCenter-6),
                        new Point(envelope.Left + 20, yCenter - heigth),
                        new Point(envelope.Right+width, yCenter - heigth),
                        new Point(envelope.Right+width, yCenter + heigth),
                        new Point(envelope.Left + 20, yCenter + heigth),
                        new Point(envelope.Left + 20, yCenter + 6)
                    };
            }
            else
            {
                currentValueTextPosition = new Point(envelope.Left - width + 4, yCenter - 8);

                currentValueIndicator = new Point[] { 
                        new Point(envelope.Right - 10, yCenter),
                        new Point(envelope.Right - 20, yCenter-6),
                        new Point(envelope.Right - 20, yCenter - heigth),
                        new Point(envelope.Left-width, yCenter - heigth),
                        new Point(envelope.Left-width, yCenter + heigth),
                        new Point(envelope.Right - 20, yCenter + heigth),
                        new Point(envelope.Right - 20, yCenter + 6)
                    };
            }
        }

        /// <summary>
        /// Draw Major Graduation.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawMajorGraduation(Graphics g, long graduationValue, int pixelCoordinate)
        {
            if (graduationValue >= MinimumValue && graduationValue <= MaximumValue)
            {
                // Major Graduation
                int gradFrom = envelope.Left;
                int gradTo = envelope.Left + 15;

                if (orientation == IndicatorOrientation.Left)
                {
                    gradFrom = envelope.Right;
                    gradTo = envelope.Right - 15;
                }

                g.DrawLine(primaryPen, gradFrom, pixelCoordinate, gradTo, pixelCoordinate);
                g.DrawString(graduationValue.ToString(), SystemFonts.DefaultFont, Brushes.White, envelope.Left + 20, pixelCoordinate - 6);

                // Minor Graduation
                if (graduationValue < MaximumValue)
                {
                    gradFrom = envelope.Left;
                    gradTo = envelope.Left + 10;
                    int ySubGrad = pixelCoordinate - (PixelPerGraduation / 2);

                    if (orientation == IndicatorOrientation.Left)
                    {
                        gradFrom = envelope.Right;
                        gradTo = envelope.Right - 10;
                    }

                    g.DrawLine(primaryPen, gradFrom, ySubGrad, gradTo, ySubGrad);
                }
            }
        }

        /// <summary>
        /// Draw Current Value Indicator.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawCurrentValueIndicator(Graphics g)
        {
            g.FillPolygon(Brushes.Black, currentValueIndicator);
            g.DrawPolygon(primaryPen, currentValueIndicator);
            g.DrawString(this.Value.ToString(), fontCurrentValue, Brushes.White, currentValueTextPosition);
        }

        /// <summary>
        /// Draw Tape.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void DrawTape(Graphics g)
        {
            if (orientation == IndicatorOrientation.Left)
            {
                g.FillRectangle(Brushes.White, envelope.Right - 5, envelope.Top, 5, envelope.Height);
            }
            else
            {
                g.FillRectangle(Brushes.White, envelope.Left, envelope.Top, 5, envelope.Height);
            }
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                g.SetClip(envelope);

                g.FillRectangle(backgroundBrush, envelope);
                g.DrawRectangle(primaryPen, envelope);

                long majorGraduationVisibleInterval = (long)Math.Truncate((double)envelope.Height / (double)PixelPerGraduation) * MajorScaleGraduation;

                long nearestMajorGraduationValue = (long)Math.Truncate((double)this.Value / (double)MajorScaleGraduation) * MajorScaleGraduation;

                int minorGraduationPixelOffset = (int)(((double)(this.Value % MajorScaleGraduation) / (double)MajorScaleGraduation) * PixelPerGraduation);

                int drawAreaLenghtPixels = (int)(majorGraduationVisibleInterval * PixelPerGraduation / MajorScaleGraduation);

                int drawAreaPaddingPixels = (envelope.Height - drawAreaLenghtPixels) / 2;

                int pixelCoordinateBegin = envelope.Bottom - drawAreaPaddingPixels + (int)minorGraduationPixelOffset;

                long firstMajor = (nearestMajorGraduationValue - majorGraduationVisibleInterval / 2);
                long lastMajor = (nearestMajorGraduationValue + MajorScaleGraduation + majorGraduationVisibleInterval / 2);

                for (long itemValue = firstMajor; itemValue <= lastMajor; itemValue += MajorScaleGraduation)
                {
                    DrawMajorGraduation(g, itemValue, pixelCoordinateBegin);
                    pixelCoordinateBegin -= PixelPerGraduation;
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
            if (primaryPen != null)
            {
                primaryPen.Dispose();
                primaryPen = null;
            }

            if (backgroundBrush != null)
            {
                backgroundBrush.Dispose();
                backgroundBrush = null;
            }
        }
    }
}
