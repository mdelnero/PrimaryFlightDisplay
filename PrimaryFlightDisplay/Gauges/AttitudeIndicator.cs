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
        IGraphicIndicator,
        IDisposable
    {
        protected Pen drawingPen = new Pen(Brushes.White, 2);

        protected Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

        protected Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

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
        /// Gets Drawing Envelope.</summary>
        public Rectangle DrawingEnvelope
        {
            get { return envelope; }
        }

        /// <summary>
        /// Gets or Sets Major Graduation Size in Pixels.</summary>
        public int PixelPerGraduation
        {
            get { return 0; }
            set {  }
        }

        /// <summary>
        /// Horizon Center Indicator.</summary>
        CenterIndicator centerIndicator;

        PitchGrid pitchGrid = new PitchGrid(80);

        /// <summary>
        /// Center Point.</summary>
        Point center;

        /// <summary>
        /// Drawing Envelope.</summary>
        /// <remarks>The Envelope is prepared every SetSize call.</remarks>
        protected Rectangle envelope;

        /// <summary>
        /// Field Of View.</summary>
        int FOV = 80;

        /// <summary>
        /// Pixel Per Degree.</summary>
        int pixelPerDegree;

        /// <summary>
        /// Constructor.</summary>
        public AttitudeIndicator()
        {
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetDrawingEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            NewEnvelope();
        }

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected virtual void NewEnvelope()
        {
            this.center = new Point(envelope.Width / 2, envelope.Height / 2);
            this.pixelPerDegree = envelope.Height / FOV;

            centerIndicator = new CenterIndicator(this.center);

            pitchGrid.SetEnvelope(envelope);
        }

        /// <summary>
        /// Draw Horizon Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public void DrawHorizon(Graphics g)
        {
            GraphicsPath skyPath = new GraphicsPath();
            skyPath.AddRectangle(new Rectangle(-envelope.Width, -envelope.Height, envelope.Width * 3, center.Y * 3 + 1));

            GraphicsPath skylinePath = new GraphicsPath();
            skylinePath.AddLine(-envelope.Width, center.Y, envelope.Width * 3, center.Y);

            GraphicsPath groundPath = new GraphicsPath();
            groundPath.AddRectangle(new Rectangle(-envelope.Width, center.Y, envelope.Width * 3, envelope.Height * 3));

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(rollAngle, center);
            transformMatrix.Translate(0, pitchAngle * pixelPerDegree);

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

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public virtual void Draw(Graphics g)
        {
            if (envelope != Rectangle.Empty)
            {
                DrawHorizon(g);

                pitchGrid.Draw(g, rollAngle, pitchAngle);

                centerIndicator.Draw(g);
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

        private class PitchGrid
        {
            protected Pen drawingPen = new Pen(Brushes.White, 2);

            /// <summary>
            /// Center Point.</summary>
            Point center;

            /// <summary>
            /// Drawing Envelope.</summary>
            Rectangle envelope;

            /// <summary>
            /// Field Of View.</summary>
            int FOV;

            /// <summary>
            /// Pixel Per Degree.</summary>
            int pixelPerDegree;

            /// <summary>
            /// Class Constructor.
            /// </summary>
            /// <param name="FOV">Field Of View.</param>
            public PitchGrid(int FOV)
            {
                this.FOV = FOV;
            }

            /// <summary>
            /// Sets Drawing Envelope.</summary>
            /// <param name="envelope">Drawing Envelope.</param>
            public void SetEnvelope(Rectangle envelope)
            {
                this.envelope = envelope;
                this.center = new Point(envelope.Width / 2, envelope.Height / 2);
                this.pixelPerDegree = envelope.Height / FOV;
            }

            /// <summary>
            /// Draw Function.</summary>
            /// <param name="g">Graphics for Drawing</param>
            public void Draw(Graphics g, float rollAngle, float pitchAngle)
            {
                Matrix transformMatrix = new Matrix();
                transformMatrix.RotateAt(rollAngle, center);
                transformMatrix.Translate(0, pitchAngle * pixelPerDegree);

                // Previous major graduation value next to currentValue.
                int majorGraduationValue = ((int)(pitchAngle / 10) * 10);

                for (int degree = majorGraduationValue - 20; degree <= majorGraduationValue + 20; degree += 5)
                {
                    if (degree == 0)
                        continue;

                    int width = degree % 10 == 0 ? 60 : 30;

                    GraphicsPath skyPath = new GraphicsPath();

                    skyPath.AddLine(center.X - width, center.Y - degree * pixelPerDegree, center.X + width, center.Y - degree * pixelPerDegree);
                    skyPath.Transform(transformMatrix);
                    g.DrawPath(drawingPen, skyPath);

                    //g.DrawString(degree.ToString(), SystemFonts.DefaultFont, Brushes.White, center.X - width - 15, center.Y - degree * 10);
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
