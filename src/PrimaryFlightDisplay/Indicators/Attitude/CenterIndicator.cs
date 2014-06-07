using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PrimaryFlightDisplay.Indicators.Attitude
{
    /// <summary>
    /// Horizon Center Indicator.</summary>
    class CenterIndicator
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
