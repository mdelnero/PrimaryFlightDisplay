using System;
using System.Drawing;

namespace PrimaryFlightDisplay
{
    /// <summary>
    /// Graphic Indicator.</summary>
    public abstract class GraphicIndicator : 
        IGraphicIndicator, 
        IDisposable
    {
        /// <summary>
        /// Drawing Envelope.</summary>
        protected Rectangle envelope;

        /// <summary>
        /// Drawing Envelope Center.</summary>
        protected Point envelopeCenter;

        /// <summary>
        /// Major Graduation Size in Pixels.</summary>
        protected int pixelPerGraduation = 50;

        /// <summary>
        /// Gets or Sets Major Graduation Size in Pixels.</summary>
        public int PixelPerGraduation
        {
            get { return pixelPerGraduation; }
            set { pixelPerGraduation = value; }
        }

        /// <summary>
        /// Gets Drawing Envelope.</summary>
        public Rectangle DrawingEnvelope
        {
            get { return envelope; }
        }

        /// <summary>
        /// Sets Drawing Envelope.</summary>
        /// <param name="envelope">Drawing Envelope.</param>
        public virtual void SetDrawingEnvelope(Rectangle envelope)
        {
            this.envelope = envelope;
            this.envelopeCenter = new Point(envelope.Width / 2, envelope.Height / 2);
            NewDrawingEnvelopeReceived();
        }

        /// <summary>
        /// New Drawing Envelope received.</summary>
        protected abstract void NewDrawingEnvelopeReceived();

        /// <summary>
        /// Draw Function.</summary>
        /// <param name="g">Graphics for Drawing</param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Dispose.</summary>
        public virtual void Dispose()
        {
        }
    }
}