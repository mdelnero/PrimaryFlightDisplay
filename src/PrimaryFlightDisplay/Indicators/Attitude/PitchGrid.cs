using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace PrimaryFlightDisplay.Indicators.Attitude
{
    class PitchGrid
    {
        protected Pen drawingPen = new Pen(Brushes.White, 2);

        /// <summary>
        /// Center Point.</summary>
        Point center;

        /// <summary>
        /// Drawing Envelope.</summary>
        Rectangle envelope;

        /// <summary>
        /// Pixel Per Degree.</summary>
        int pixelPerDegree;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        public PitchGrid()
        {
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public void SetEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            this.center = new Point(envelope.Width / 2, envelope.Height / 2);
            this.pixelPerDegree = envelope.Height / AttitudeIndicator.FOV;
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
}
