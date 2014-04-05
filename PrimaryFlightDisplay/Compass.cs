using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrimaryFlightDisplay
{
    public class Compass : GraphicGauge
    {
        /// <summary>
        /// Pen.</summary>
        private readonly Pen drawingPen = new Pen(Brushes.White, 1);

        /// <summary>
        /// Brush.</summary>
        private readonly Brush drawingBrush = new SolidBrush(Color.Gray);

        /// <summary>
        /// Informs Parent Drawing size.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        public override void SetParentSize(int parentWidth, int parentHeigth)
        {
            base.SetParentSize(parentWidth, parentHeigth);
            PrepareDrawingElements();
        }

        /// <summary>
        /// Makes the Drawing Envelope.</summary>
        /// <param name="parentWidth">Parent Graphics Width.</param>
        /// <param name="parentHeigth">Parent Graphics Heigth.</param>
        /// <returns>The Drawing Envelope.</returns>
        public override Rectangle MakeEnvelope()
        {
            return new Rectangle(parentWidth / 4, parentHeigth - 100, 300, 300);
        }

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(drawingPen, envelope);
            g.FillEllipse(drawingBrush, envelope);
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrepareDrawingElements()
        {
        }
    }
}
