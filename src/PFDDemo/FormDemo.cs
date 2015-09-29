using PrimaryFlightDisplay;
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

            UpdateAltitudeGaugeParams();
            
            // Test
        }

        void UpdateAltitudeGaugeParams()
        {
            IPrimaryFlightDisplay pfd = pfdControl1 as IPrimaryFlightDisplay;

            pfd.Altitude.Value = trackAltitudeValue.Value;
            pfd.Altitude.MinimumValue = trackAltitudeMin.Value;
            pfd.Altitude.MaximumValue = trackAltitudeMax.Value;

            pfd.AirSpeed.Value = trackAirSpeedValue.Value;
            pfd.AirSpeed.MinimumValue = trackAirSpeedMin.Value;
            pfd.AirSpeed.MaximumValue = trackAirSpeedMax.Value;

            pfd.Heading.Value = trackCompassValue.Value;

            pfd.AttitudeIndicator.RollAngle = trackHorizonRoll.Value;
            pfd.AttitudeIndicator.PitchAngle = trackHorizonPitch.Value;

            pfdControl1.Redraw();
        }

        private void trackAltitudeMin_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (trackAltitudeValue.Value < trackAltitudeMin.Value)
                {
                    trackAltitudeValue.Value = trackAltitudeMin.Value;
                }

                trackAltitudeValue.Minimum = trackAltitudeMin.Value;
                labelAltitudeMinValue.Text = trackAltitudeMin.Value.ToString();

                UpdateAltitudeGaugeParams();
            }
            catch (Exception) { }
        }

        private void trackAltitudeMax_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (trackAltitudeValue.Value > trackAltitudeMax.Value)
                {
                    trackAltitudeValue.Value = trackAltitudeMax.Value;
                }

                trackAltitudeValue.Maximum = trackAltitudeMax.Value;
                labelAltitudeMaxValue.Text = trackAltitudeMax.Value.ToString();

                UpdateAltitudeGaugeParams();
            }
            catch (Exception) { }
        }

        private void trackAltitudeValue_Scroll(object sender, EventArgs e)
        {
            UpdateAltitudeGaugeParams();
        }

        private void trackAirSpeedValue_Scroll(object sender, EventArgs e)
        {
            UpdateAltitudeGaugeParams();
        }

        private void trackAirSpeedMin_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (trackAirSpeedValue.Value < trackAirSpeedMin.Value)
                {
                    trackAirSpeedValue.Value = trackAirSpeedMin.Value;
                }

                trackAirSpeedValue.Minimum = trackAirSpeedMin.Value;
                labelAirSpeedMinValue.Text = trackAirSpeedMin.Value.ToString();

                UpdateAltitudeGaugeParams();
            }
            catch (Exception) { }

        }

        private void trackAirSpeedMax_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (trackAirSpeedValue.Value > trackAirSpeedMax.Value)
                {
                    trackAirSpeedValue.Value = trackAirSpeedMax.Value;
                }

                trackAirSpeedValue.Maximum = trackAirSpeedMax.Value;
                labelAirSpeedMaxValue.Text = trackAirSpeedMax.Value.ToString();

                UpdateAltitudeGaugeParams();
            }
            catch (Exception) { }
        }

        private void trackCompassValue_Scroll(object sender, EventArgs e)
        {
            UpdateAltitudeGaugeParams();
        }

        private void trackHorizonPitch_Scroll(object sender, EventArgs e)
        {
            UpdateAltitudeGaugeParams();
        }

        private void trackHorizonRoll_Scroll(object sender, EventArgs e)
        {
            UpdateAltitudeGaugeParams();
        }
    }
}
