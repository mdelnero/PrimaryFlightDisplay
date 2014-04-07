using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PrimaryFlightDisplay.Gauges;

namespace PrimaryFlightDisplay
{
    public partial class PFDControl : UserControl
    {
        /// <summary>
        /// AirSpeed Gauge.</summary>
        public VerticalBar AirspeedGauge = new VerticalBar();

        /// <summary>
        /// Altitude Gauge.</summary>
        public VerticalBar AltitudeGauge = new VerticalBar();

        /// <summary>
        /// Compass.</summary>
        public Compass CompassGauge = new Compass();

        /// <summary>
        /// Artificial Horizon.</summary>
        public ArtificialHorizon Horizon = new ArtificialHorizon();

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
            AltitudeGauge.DockPosition = VerticalBar.GaugeDockPosition.DockRight;
            AltitudeGauge.MinimumValue = 0;
            AltitudeGauge.MaximumValue = 200;
            AltitudeGauge.MajorGraduation = 20;
            AltitudeGauge.NeverExceedValue = 100;

            AirspeedGauge.DockPosition = VerticalBar.GaugeDockPosition.DockLeft;
            AirspeedGauge.MinimumValue = 0;
            AirspeedGauge.MaximumValue = 20;
            AirspeedGauge.MajorGraduation = 5;            
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
            Horizon.SetEnvelope(this.DisplayRectangle);

            Rectangle altitudeRect = new Rectangle();

            altitudeRect.Width = (int)(this.Width * 0.15f);
            altitudeRect.Height = (int)(this.Height * 0.5f);
            altitudeRect.Y = (this.Height - altitudeRect.Height) / 2;
            altitudeRect.X = (this.Width - altitudeRect.Width);

            AltitudeGauge.SetEnvelope(altitudeRect);

            Rectangle airspeedRect = new Rectangle();

            airspeedRect.Width = (int)(this.Width * 0.15f);
            airspeedRect.Height = (int)(this.Height * 0.5f);
            airspeedRect.Y = (this.Height - airspeedRect.Height) / 2;
            airspeedRect.X = 0;
            
            AirspeedGauge.SetEnvelope(airspeedRect);

            Rectangle compassRect = new Rectangle();

            compassRect.Width = 350;
            compassRect.Height = 50;
            compassRect.Y = (this.Bottom - compassRect.Height);
            compassRect.X = (this.Right - compassRect.Width) / 2; ;

            CompassGauge.SetEnvelope(compassRect);

            Redraw();
        }

        private void GraphicUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Horizon.Draw(g);
            AirspeedGauge.Draw(g);
            AltitudeGauge.Draw(g);
            CompassGauge.Draw(g);
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
