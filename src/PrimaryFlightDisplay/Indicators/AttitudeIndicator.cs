using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using PrimaryFlightDisplay.Indicators.Attitude;
using PrimaryFlightDisplay.Drawing;

namespace PrimaryFlightDisplay.Indicators
{
    internal class AttitudeIndicator :
        IAttitudeIndicator,
        IGraphicCanvas,
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
            set { }
        }

        /// <summary>
        /// Horizon Center Indicator.</summary>
        CenterIndicator centerIndicator;

        PitchGrid pitchGrid = new PitchGrid();

        /// <summary>
        /// Center Point.</summary>
        Point center;

        /// <summary>
        /// Drawing Envelope.</summary>
        /// <remarks>The Envelope is prepared every SetSize call.</remarks>
        protected Rectangle envelope;

        /// <summary>
        /// Field Of View.</summary>
        static public  int FOV = 60;

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
            int half180inPixels = pixelPerDegree * 180;

            GraphicsPath skyPath = new GraphicsPath();
            skyPath.AddRectangle(new Rectangle(-envelope.Width, center.Y - half180inPixels, envelope.Width * 3, half180inPixels));
            skyPath.AddRectangle(new Rectangle(-envelope.Width, center.Y + half180inPixels, envelope.Width * 3, half180inPixels));

            GraphicsPath groundPath = new GraphicsPath();
            groundPath.AddRectangle(new Rectangle(-envelope.Width, center.Y, envelope.Width * 3, half180inPixels));
            groundPath.AddRectangle(new Rectangle(-envelope.Width, center.Y - half180inPixels * 2, envelope.Width * 3, half180inPixels));

            GraphicsPath skylinePath = new GraphicsPath();
            skylinePath.AddLine(-envelope.Width, center.Y, envelope.Width * 3, center.Y);
            skylinePath.CloseFigure();
            skylinePath.AddLine(-envelope.Width, center.Y - half180inPixels, envelope.Width * 3, center.Y - half180inPixels);
            skylinePath.CloseFigure();
            skylinePath.AddLine(-envelope.Width, center.Y + half180inPixels, envelope.Width * 3, center.Y + half180inPixels);



            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(rollAngle, center);
            transformMatrix.Translate(0, pitchAngle * pixelPerDegree);

            skyPath.Transform(transformMatrix);
            groundPath.Transform(transformMatrix);
            skylinePath.Transform(transformMatrix);

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
    }
}
