using PrimaryFlightDisplay.Indicators;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimaryFlightDisplay
{
    public partial class PFDControl :
        UserControl,
        IPrimaryFlightDisplay
    {
        /// <summary>
        /// Air Speed.</summary>
        private VerticalIndicator airspeed = new VerticalIndicator();

        /// <summary>
        /// Altitude Gauge.</summary>
        private VerticalIndicator altitude = new VerticalIndicator();

        /// <summary>
        /// Compass.</summary>
        private HeadingIndicator heading = new HeadingIndicator();

        /// <summary>
        /// Artificial Horizon.</summary>
        private AttitudeIndicator attitudeIndicator = new AttitudeIndicator();

        /// <summary>
        /// Air Speed Indicator.</summary>
        public IIndicator AirSpeed
        {
            get { return airspeed; }
        }

        /// <summary>
        /// Altitude Indicator.</summary>
        public IIndicator Altitude
        {
            get { return altitude; }
        }

        /// <summary>
        /// Heading Indicator.</summary>
        public IIndicator Heading
        {
            get { return heading; }
        }

        /// <summary>
        /// Attitude Indicator.</summary>
        public IAttitudeIndicator AttitudeIndicator
        {
            get { return attitudeIndicator; }
        }

        /// <summary>
        /// Class Constructor.
        /// </summary>
        public PFDControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            InitializeGauges();
        }

        /// <summary>
        /// Initialize Gauges.</summary>
        protected void InitializeGauges()
        {
            altitude.Orientation = IndicatorOrientation.Right;
            altitude.MinimumValue = 0;
            altitude.MaximumValue = 200;
            altitude.MajorScaleGraduation = 20;

            airspeed.Orientation = IndicatorOrientation.Left;
            airspeed.MinimumValue = 0;
            airspeed.MaximumValue = 20;
        }

        /// <summary>
        /// Redraw User Control.</summary>
        public void Redraw()
        {
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void GraphicUserControl_Resize(object sender, EventArgs e)
        {
            attitudeIndicator.SetDrawingEnvelope(this.DisplayRectangle);

            Rectangle altitudeRect = new Rectangle();

            altitudeRect.Height = 300;
            altitudeRect.Width = 60;
            altitudeRect.Y = (this.Height - altitudeRect.Height) / 2;
            altitudeRect.X = (this.Width - altitudeRect.Width - 20);

            altitude.SetDrawingEnvelope(altitudeRect);

            Rectangle airspeedRect = new Rectangle();

            airspeedRect.Height = 300;
            airspeedRect.Width = 60;
            airspeedRect.Y = (this.Height - airspeedRect.Height) / 2;
            airspeedRect.X = 20;

            airspeed.SetDrawingEnvelope(airspeedRect);

            Rectangle compassRect = new Rectangle();

            compassRect.Width = 250;
            compassRect.Height = 40;
            compassRect.Y = (this.Bottom - compassRect.Height - 20);
            compassRect.X = (this.Right - compassRect.Width) / 2;

            heading.SetDrawingEnvelope(compassRect);

            Redraw();
        }

        private void GraphicUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            attitudeIndicator.Draw(g);
            airspeed.Draw(g);
            altitude.Draw(g);
            heading.Draw(g);
        }

        private void GraphicUserControl_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void GraphicUserControl_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void GraphicUserControl_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
