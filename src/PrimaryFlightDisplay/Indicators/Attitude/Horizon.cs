using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PrimaryFlightDisplay.Indicators.Attitude
{
    class Horizon
    {
        protected Pen drawingPen = new Pen(Brushes.White, 2);

        protected Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

        protected Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

        /// <summary>
        /// Drawing Envelope.</summary>
        Rectangle envelope;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        /// <param name="FOV">Field Of View.</param>
        public Horizon()
        {
        }

        public void Create()
        {

        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public void SetEnvelope(Rectangle envelope)
        {

        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public void Draw(Graphics g)
        {
        }
    }
}
