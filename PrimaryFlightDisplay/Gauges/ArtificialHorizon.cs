using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PrimaryFlightDisplay.Gauges
{
    public class ArtificialHorizon : IGraphicControl, IDisposable
    {
        /// <summary>
        /// Roll Angle.</summary>
        protected float rollAngle;

        /// <summary>
        /// Gets or Sets Roll Angle.</summary>
        public float RollAngle
        {
            get { return rollAngle; }
            set { rollAngle = value; }
        }

        /// <summary>
        /// Pitch Angle.</summary>
        protected float pitchAngle;

        /// <summary>
        /// Gets or Sets Pitch Angle.</summary>
        public float PitchAngle
        {
            get { return pitchAngle; }
            set { pitchAngle = value; }
        }

        protected Pen drawingPen = new Pen(Brushes.White, 2);

        protected Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

        protected Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

        /// <summary>
        /// Horizon Center Indicator.</summary>
        CenterIndicator horizonCenter;

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

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                Point center = new Point(envelope.Width / 2, envelope.Height / 2);

                GraphicsPath skyPath = new GraphicsPath();
                skyPath.AddRectangle(new Rectangle(-envelope.Width, -envelope.Height, envelope.Width * 3, center.Y * 3 + 1));

                GraphicsPath groundPath = new GraphicsPath();
                groundPath.AddRectangle(new Rectangle(-envelope.Width, center.Y, envelope.Width * 3, envelope.Height * 3));

                g.SetClip(envelope);

                Matrix transformMatrix = new Matrix();

                transformMatrix.RotateAt(rollAngle, center);
                transformMatrix.Translate(0, pitchAngle);

                skyPath.Transform(transformMatrix);
                groundPath.Transform(transformMatrix);

                g.FillPath(skyBrush, skyPath);
                g.FillPath(groundBrush, groundPath);

                skyPath.Dispose();
                groundPath.Dispose();

                horizonCenter.Draw(g);

                g.ResetClip();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void PrepareDrawingElements()
        {
            horizonCenter = new CenterIndicator(new Point(envelope.Width / 2, envelope.Height / 2));
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

        /// <summary>
        /// Horizon Center Indicator.</summary>
        private class CenterIndicator
        {
            private Rectangle centerIndicator;

            private Point[] leftIndicator;

            private Point[] rightIndicator;

            public CenterIndicator(Point center)
            {
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

            public void Draw(Graphics g)
            {
                g.FillRectangle(Brushes.Yellow, centerIndicator);
                g.DrawRectangle(Pens.Black, centerIndicator);

                g.FillPolygon(Brushes.Yellow, leftIndicator);
                g.DrawPolygon(Pens.Black, leftIndicator);

                g.FillPolygon(Brushes.Yellow, rightIndicator);
                g.DrawPolygon(Pens.Black, rightIndicator);
            }
        }
    }
}
