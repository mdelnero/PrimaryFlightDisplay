using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PFDDemo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();            
            pfdControl1.altitudeGauge.Value = trackBar1.Value;
            pfdControl1.speedGauge.Value = trackBar2.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pfdControl1.altitudeGauge.Value = trackBar1.Value;
            pfdControl1.Redraw();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pfdControl1.speedGauge.Value = trackBar2.Value;
            pfdControl1.Redraw();

        }
    }
}
