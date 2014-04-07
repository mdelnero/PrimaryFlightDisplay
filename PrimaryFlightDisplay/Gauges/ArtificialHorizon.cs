using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrimaryFlightDisplay.Gauges
{
    public class ArtificialHorizon : IGraphicControl, IDisposable
    {
        protected Pen drawingPen = new Pen(Brushes.White, 2);

        protected Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

        protected Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

        protected Rectangle centerIndicator;

        protected Point[] leftIndicator;

        protected Point[] rightIndicator;

        /// <summary>
        /// Drawing Envelope.</summary>
        /// <remarks>The Envelope is prepared every SetSize call.</remarks>
        protected Rectangle envelope;

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            PrepareDrawingElements();
        }

        protected void DrawCenter(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow, centerIndicator);
            g.DrawRectangle(Pens.Black, centerIndicator);

            g.FillPolygon(Brushes.Yellow, leftIndicator);
            g.DrawPolygon(Pens.Black, leftIndicator);

            g.FillPolygon(Brushes.Yellow, rightIndicator);
            g.DrawPolygon(Pens.Black, rightIndicator);
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                Point center = new Point(envelope.Width / 2, envelope.Height / 2);

                g.SetClip(envelope);

                g.FillRectangle(skyBrush, 0, 0, envelope.Width, center.Y);
                g.FillRectangle(groundBrush, 0, center.Y, envelope.Width, envelope.Height);
                g.DrawLine(drawingPen, 0, center.Y, envelope.Width, center.Y);

                DrawCenter(g);

                g.ResetClip();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void PrepareDrawingElements()
        {
            Point center = new Point(envelope.Width / 2, envelope.Height / 2);

            int width = 4;

            centerIndicator = new Rectangle(center.X - 4, center.Y - 4, 8, 8);

            leftIndicator = new Point[] { 
                new Point(center.X - 100, center.Y - width),
                new Point(center.X - 40, center.Y - width),
                new Point(center.X - 40, center.Y + 13),
                new Point(center.X - 40 - (width*2), center.Y + 13),
                new Point(center.X - 40 - (width*2), center.Y + width),
                new Point(center.X - 100, center.Y + width),
            };

            rightIndicator = new Point[] { 
                new Point(center.X + 40, center.Y - width),
                new Point(center.X + 100, center.Y - width),
                new Point(center.X + 100, center.Y + width),
                new Point(center.X + 40 + (width*2), center.Y + width),
                new Point(center.X + 40 + (width*2), center.Y + 13),
                new Point(center.X + 40, center.Y + 13)
            };

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

            if (skyBrush != null)
            {
                skyBrush.Dispose();
                skyBrush = null;
            }

            if (groundBrush != null)
            {
                groundBrush.Dispose();
                groundBrush = null;
            }
        }
    }
}
