using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PrimaryFlightDisplay.Gauges
{
    internal class AttitudeIndicator :
        IAttitudeIndicator,
        IGraphicControl,
        IDisposable
    {
        protected Pen drawingPen = new Pen(Brushes.White, 2);

        /// <summary>
        /// Roll Angle.</summary>
        protected float rollAngle;

        /// <summary>
        /// Pitch Angle.</summary>
        protected float pitchAngle;

        /// <summary>
        /// Gets or Sets Roll Angle.</summary>
        public float RollAngle
        {
            get { return rollAngle; }
            set { rollAngle = value; }
        }

        /// <summary>
        /// Gets or Sets Pitch Angle.</summary>
        public float PitchAngle
        {
            get { return pitchAngle; }
            set { pitchAngle = value; }
        }

        /// <summary>
        /// Horizon Center Indicator.</summary>
        CenterIndicator centerIndicator;

        /// <summary>
        /// Artificial Horizon.</summary>
        ArtificialHorizon horizon = new ArtificialHorizon();

        /// <summary>
        /// Drawing Envelope.</summary>
        /// <remarks>The Envelope is prepared every SetSize call.</remarks>
        protected Rectangle envelope;

        /// <summary>
        /// Constructor.</summary>
        public AttitudeIndicator()
        {
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            NewEnvelope();
        }

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected virtual void NewEnvelope()
        {
            centerIndicator = new CenterIndicator(new Point(envelope.Width / 2, envelope.Height / 2));

            horizon.SetEnvelope(envelope);
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                horizon.Draw(g, rollAngle, pitchAngle);

                centerIndicator.Draw(g);

                // If you rotate point (px, py) around point (ox, oy) by angle theta you'll get:
                //p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
                //p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy

                //Point center = new Point(envelope.Width / 2, envelope.Height / 2);

                //for (int degree = 5; degree <= 30; degree += 5)
                //{
                //    int width = degree % 10 != 0 ? 30 : 60;

                //    g.DrawLine(drawingPen, center.X - width, center.Y - degree * 10, center.X + width, center.Y - degree * 10);

                //    if (width == 60)
                //    { 
                //        g.DrawString(degree.ToString(), SystemFonts.DefaultFont, Brushes.White, center.X - width - 20, center.Y - 5 - degree * 10);
                //        g.DrawString(degree.ToString(), SystemFonts.DefaultFont, Brushes.White, center.X + width +10, center.Y - 5 - degree * 10);
                //    }
                //}
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

        /// <summary>
        /// Artificial Horizon.</summary>
        private class ArtificialHorizon
        {
            /// <summary>
            /// Center Point.</summary>
            Point center;

            /// <summary>
            /// Drawing Envelope.</summary>
            Rectangle envelope;

            protected Pen drawingPen = new Pen(Brushes.White, 2);

            protected Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

            protected Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

            /// <summary>
            /// Sets Drawing Envelope.</summary>
            /// <param name="envelope">Drawing Envelope.</param>
            public void SetEnvelope(Rectangle envelope)
            {
                this.envelope = envelope;
                this.center = new Point(envelope.Width / 2, envelope.Height / 2);
            }

            /// <summary>
            /// Draw Function.</summary>
            /// <param name="g">Graphics for Drawing</param>
            public void Draw(Graphics g, float rollAngle, float pitchAngle)
            {
                if (envelope != Rectangle.Empty)
                {
                    GraphicsPath skyPath = new GraphicsPath();
                    skyPath.AddRectangle(new Rectangle(-envelope.Width, -envelope.Height, envelope.Width * 3, center.Y * 3 + 1));

                    GraphicsPath skylinePath = new GraphicsPath();
                    skylinePath.AddLine(-envelope.Width, center.Y, envelope.Width * 3, center.Y);

                    GraphicsPath groundPath = new GraphicsPath();
                    groundPath.AddRectangle(new Rectangle(-envelope.Width, center.Y, envelope.Width * 3, envelope.Height * 3));

                    Matrix transformMatrix = new Matrix();
                    transformMatrix.RotateAt(rollAngle, center);
                    transformMatrix.Translate(0, pitchAngle);

                    skyPath.Transform(transformMatrix);
                    skylinePath.Transform(transformMatrix);
                    groundPath.Transform(transformMatrix);

                    g.SetClip(envelope);

                    g.FillPath(skyBrush, skyPath);
                    g.FillPath(groundBrush, groundPath);
                    g.DrawPath(drawingPen, skylinePath);

                    g.ResetClip();

                    skyPath.Dispose();
                    skylinePath.Dispose();
                    groundPath.Dispose();
                }
            }
        }

        /// <summary>
        /// Horizon Center Indicator.</summary>
        private class CenterIndicator
        {
            /// <summary>
            /// Center Rectangle.</summary>
            private Rectangle centerIndicator;

            /// <summary>
            /// Left Wing.</summary>
            private Point[] leftIndicator;

            /// <summary>
            /// Right Wing.</summary>
            private Point[] rightIndicator;

            /// <summary>
            /// Constructor.</summary>
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

            /// <summary>
            /// Draw Function.</summary>
            /// <param name="g">Graphics for Drawing</param>
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
