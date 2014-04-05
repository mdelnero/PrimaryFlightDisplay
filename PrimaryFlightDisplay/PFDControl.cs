using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PrimaryFlightDisplay
{
    public partial class PFDControl : UserControl
    {
        private readonly Brush skyBrush = new SolidBrush(Color.FromArgb(0, 204, 255));

        private readonly Brush groundBrush = new SolidBrush(Color.FromArgb(153, 102, 51));

        public VerticalGauge altitudeGauge = new VerticalGauge();
        public VerticalGauge speedGauge = new VerticalGauge();
        public Compass compassGauge = new Compass();

        private List<IGraphicGauge> gaugeList = new List<IGraphicGauge>();

        public PFDControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            altitudeGauge.DockPosition = GaugeDockPosition.DockRight;
            altitudeGauge.MinimumValue = 0;
            altitudeGauge.MaximumValue = 500;
            altitudeGauge.GaugeIncrement = 10;

            speedGauge.DockPosition = GaugeDockPosition.DockLeft;
            altitudeGauge.MinimumValue = 0;
            speedGauge.MaximumValue = 20;

            gaugeList.Add(altitudeGauge);
            gaugeList.Add(speedGauge);
            // gaugeList.Add(compassGauge);

        }

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
            foreach (IGraphicGauge gauge in gaugeList)
            {
                gauge.SetParentSize(this.Width, this.Height);
            }

            Redraw();
        }

        private void GraphicUserControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(skyBrush, 0, 0, this.Width, this.Height / 2);
            g.FillRectangle(groundBrush, 0, this.Height / 2, this.Width, this.Height);

            foreach (IGraphicGauge gauge in gaugeList)
            {
                gauge.Draw(g);
            }
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
