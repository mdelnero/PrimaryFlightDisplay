using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PrimaryFlightDisplay.Gauges;

namespace PrimaryFlightDisplay
{
    public partial class PFDControl :
        UserControl,
        IPrimaryFlightDisplay
    {
        /// <summary>
        /// Air Speed.</summary>
        private VerticalTape airspeedGauge = new VerticalTape();

        /// <summary>
        /// Altitude Gauge.</summary>
        private VerticalTape altitudeGauge = new VerticalTape();

        /// <summary>
        /// Compass.</summary>
        private Compass compassGauge = new Compass();

        /// <summary>
        /// Artificial Horizon.</summary>
        private AttitudeIndicator attitudeIndicator = new AttitudeIndicator();

        /// <summary>
        /// Air Speed Tape.</summary>
        public IGauge AirSpeed 
        { 
            get {return airspeedGauge;}
        }

        /// <summary>
        /// Altitude Tape.</summary>
        public IGauge Altitude
        {
            get { return altitudeGauge; }
        }

        /// <summary>
        /// Compass.</summary>
        public IGauge Compass
        {
            get { return compassGauge; }
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
            altitudeGauge.DockPosition = VerticalTape.GaugeDockPosition.DockRight;
            altitudeGauge.MinimumValue = 0;
            altitudeGauge.MaximumValue = 200;
            altitudeGauge.MajorGraduation = 20;
            altitudeGauge.NeverExceedValue = 100;

            airspeedGauge.DockPosition = VerticalTape.GaugeDockPosition.DockLeft;
            airspeedGauge.MinimumValue = 0;
            airspeedGauge.MaximumValue = 20;
            airspeedGauge.MajorGraduation = 5;            
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
            attitudeIndicator.SetEnvelope(this.DisplayRectangle);

            Rectangle altitudeRect = new Rectangle();

            altitudeRect.Width = (int)(this.Width * 0.15f);
            altitudeRect.Height = (int)(this.Height * 0.5f);
            altitudeRect.Y = (this.Height - altitudeRect.Height) / 2;
            altitudeRect.X = (this.Width - altitudeRect.Width);

            altitudeGauge.SetEnvelope(altitudeRect);

            Rectangle airspeedRect = new Rectangle();

            airspeedRect.Width = (int)(this.Width * 0.15f);
            airspeedRect.Height = (int)(this.Height * 0.5f);
            airspeedRect.Y = (this.Height - airspeedRect.Height) / 2;
            airspeedRect.X = 0;
            
            airspeedGauge.SetEnvelope(airspeedRect);

            Rectangle compassRect = new Rectangle();

            compassRect.Width = 350;
            compassRect.Height = 50;
            compassRect.Y = (this.Bottom - compassRect.Height);
            compassRect.X = (this.Right - compassRect.Width) / 2; ;

            compassGauge.SetEnvelope(compassRect);

            Redraw();
        }

        private void GraphicUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            attitudeIndicator.Draw(g);
            airspeedGauge.Draw(g);
            altitudeGauge.Draw(g);
            compassGauge.Draw(g);
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
