using System;
using System.Drawing;

namespace PrimaryFlightDisplay.Gauges
{
    public class VerticalBar : GraphicGauge, IDisposable
    {
        public enum GaugeDockPosition
        {
            DockLeft,
            DockRight
        }

        /// <summary>
        /// Size of Major Graduation in Pixels
        /// </summary>
        protected const int PixelPerGraduation = 40;

        /// <summary>
        /// Pen.</summary>
        protected Pen drawingPen = new Pen(Brushes.White, 2);

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
        /// Current Value Text Point.</summary>
        /// <remarks>The Text Point is prepared every SetParentSize call.</remarks>
        protected Point currentValueIndicator;

        /// <summary>
        /// Current Value Drawing Indicator.</summary>
        /// <remarks>The Drawing Indicator is prepared every SetParentSize call.</remarks>
        protected Point[] currentIndicator;

        public VerticalBar()
            : base()
        {
            dock = GaugeDockPosition.DockLeft;
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public override void SetEnvelope(Rectangle envelope)
        {
            base.SetEnvelope(envelope);
            PrepareDrawingElements();
        }

        /// <summary>
        /// Draw Major Graduation.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawMajorGraduation(Graphics g, long graduationValue, int pixelCoordinate)
        {
            if (graduationValue >= minimumValue && graduationValue <= maximumValue)
            {
                // Major Graduation
                int gradFrom = envelope.Left;
                int gradTo = envelope.Left + 15;

                if (dock == GaugeDockPosition.DockLeft)
                {
                    gradFrom = envelope.Right;
                    gradTo = envelope.Right - 15;
                }

                g.DrawLine(drawingPen, gradFrom, pixelCoordinate, gradTo, pixelCoordinate);
                g.DrawString(graduationValue.ToString(), SystemFonts.DefaultFont, Brushes.White, envelope.Left + 20, pixelCoordinate - 6);

                // Minor Graduation
                if (graduationValue < maximumValue)
                {
                    gradFrom = envelope.Left;
                    gradTo = envelope.Left + 10;
                    int ySubGrad = pixelCoordinate - (PixelPerGraduation / 2);

                    if (dock == GaugeDockPosition.DockLeft)
                    {
                        gradFrom = envelope.Right;
                        gradTo = envelope.Right - 10;
                    }

                    g.DrawLine(drawingPen, gradFrom, ySubGrad, gradTo, ySubGrad);
                }
            }
        }

        /// <summary>
        /// Draw Current Value Indicator.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawCurrentValueIndicator(Graphics g)
        {
            g.FillPolygon(Brushes.Black, currentIndicator);
            g.DrawPolygon(drawingPen, currentIndicator);
            g.DrawString(currentValue.ToString(), SystemFonts.DefaultFont, Brushes.White, currentValueIndicator);
        }

        /// <summary>
        /// Draw Tape.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void DrawTape(Graphics g)
        {
            if (dock == GaugeDockPosition.DockLeft)
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

                g.DrawRectangle(drawingPen, envelope);

                // Previous major graduation value next to currentValue.
                long majorGraduationValue = (currentValue / majorGraduation) * majorGraduation;

                // First major graduation value on screen
                long majorGraduationBottomInterval = envelope.Height / PixelPerGraduation / 2 * majorGraduation;

                // Current value pixel offset
                long currentValuePixelOffset = (long)(((float)(currentValue % majorGraduation) / (float)majorGraduation) * PixelPerGraduation);

                int drawAreaLenght = (int)(majorGraduationBottomInterval * 2 * PixelPerGraduation / majorGraduation); // In Pixels

                int drawAreaPadding = (envelope.Height - drawAreaLenght) / 2;

                int pixelCoordinateBegin = envelope.Bottom - drawAreaPadding + (int)currentValuePixelOffset;

                for (long itemValue = (majorGraduationValue - majorGraduationBottomInterval);
                    itemValue <= (majorGraduationValue + majorGraduationBottomInterval + majorGraduation);
                    itemValue += majorGraduation)
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
        /// 
        /// </summary>
        protected virtual void PrepareDrawingElements()
        {
            int yCenter = (envelope.Top + envelope.Bottom) / 2;

            currentValueIndicator = new Point(envelope.Left + 25, yCenter - 6);

            if (dock == GaugeDockPosition.DockRight)
            {
                currentIndicator = new Point[] { 
                        new Point(envelope.Left + 10, yCenter) ,
                        new Point(envelope.Left + 20, yCenter - 10) ,
                        new Point(envelope.Right, yCenter - 10) ,
                        new Point(envelope.Right, yCenter + 10) ,
                        new Point(envelope.Left + 20, yCenter + 10)
                    };
            }
            else
            {
                currentIndicator = new Point[] { 
                        new Point(envelope.Right - 10, yCenter) ,
                        new Point(envelope.Right - 20, yCenter - 10) ,
                        new Point(envelope.Left, yCenter - 10) ,
                        new Point(envelope.Left, yCenter + 10) ,
                        new Point(envelope.Right - 20, yCenter + 10)
                    };
            }
        }

        /// <summary>
        /// Dispose.</summary>
        public virtual void Dispose()
        {
            if (drawingPen != null)
            {
                drawingPen.Dispose();
                drawingPen = null;
            }
        }
    }
}
