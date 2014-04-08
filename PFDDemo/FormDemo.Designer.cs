namespace PFDDemo
{
    partial class FormDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxHorizon = new System.Windows.Forms.GroupBox();
            this.trackHorizonRoll = new System.Windows.Forms.TrackBar();
            this.trackHorizonPitch = new System.Windows.Forms.TrackBar();
            this.groupBoxCompass = new System.Windows.Forms.GroupBox();
            this.trackCompassValue = new System.Windows.Forms.TrackBar();
            this.groupBoxAirSpeed = new System.Windows.Forms.GroupBox();
            this.labelAirSpeedMaxValue = new System.Windows.Forms.Label();
            this.labelAirSpeedMinValue = new System.Windows.Forms.Label();
            this.labelAirSpeedMinimum = new System.Windows.Forms.Label();
            this.trackAirSpeedValue = new System.Windows.Forms.TrackBar();
            this.trackAirSpeedMax = new System.Windows.Forms.TrackBar();
            this.labelAirSpeedMaximum = new System.Windows.Forms.Label();
            this.trackAirSpeedMin = new System.Windows.Forms.TrackBar();
            this.groupBoxAltitude = new System.Windows.Forms.GroupBox();
            this.labelAltitudeMaxValue = new System.Windows.Forms.Label();
            this.labelAltitudeMinValue = new System.Windows.Forms.Label();
            this.labelAltitudeMinimum = new System.Windows.Forms.Label();
            this.trackAltitudeValue = new System.Windows.Forms.TrackBar();
            this.trackAltitudeMax = new System.Windows.Forms.TrackBar();
            this.labelAltitudeMaximum = new System.Windows.Forms.Label();
            this.trackAltitudeMin = new System.Windows.Forms.TrackBar();
            this.pfdControl1 = new PrimaryFlightDisplay.PFDControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxHorizon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHorizonRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHorizonPitch)).BeginInit();
            this.groupBoxCompass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCompassValue)).BeginInit();
            this.groupBoxAirSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedMin)).BeginInit();
            this.groupBoxAltitude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxHorizon);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxCompass);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAirSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAltitude);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pfdControl1);
            this.splitContainer1.Size = new System.Drawing.Size(770, 591);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxHorizon
            // 
            this.groupBoxHorizon.Controls.Add(this.trackHorizonRoll);
            this.groupBoxHorizon.Controls.Add(this.trackHorizonPitch);
            this.groupBoxHorizon.Location = new System.Drawing.Point(12, 421);
            this.groupBoxHorizon.Name = "groupBoxHorizon";
            this.groupBoxHorizon.Size = new System.Drawing.Size(243, 120);
            this.groupBoxHorizon.TabIndex = 10;
            this.groupBoxHorizon.TabStop = false;
            this.groupBoxHorizon.Text = "Artificial Horizon";
            // 
            // trackHorizonRoll
            // 
            this.trackHorizonRoll.Location = new System.Drawing.Point(6, 69);
            this.trackHorizonRoll.Maximum = 180;
            this.trackHorizonRoll.Minimum = -180;
            this.trackHorizonRoll.Name = "trackHorizonRoll";
            this.trackHorizonRoll.Size = new System.Drawing.Size(228, 45);
            this.trackHorizonRoll.TabIndex = 8;
            this.trackHorizonRoll.TickFrequency = 36;
            this.trackHorizonRoll.Scroll += new System.EventHandler(this.trackHorizonRoll_Scroll);
            // 
            // trackHorizonPitch
            // 
            this.trackHorizonPitch.Location = new System.Drawing.Point(7, 28);
            this.trackHorizonPitch.Maximum = 180;
            this.trackHorizonPitch.Minimum = -180;
            this.trackHorizonPitch.Name = "trackHorizonPitch";
            this.trackHorizonPitch.Size = new System.Drawing.Size(228, 45);
            this.trackHorizonPitch.TabIndex = 7;
            this.trackHorizonPitch.TickFrequency = 36;
            this.trackHorizonPitch.Scroll += new System.EventHandler(this.trackHorizonPitch_Scroll);
            // 
            // groupBoxCompass
            // 
            this.groupBoxCompass.Controls.Add(this.trackCompassValue);
            this.groupBoxCompass.Location = new System.Drawing.Point(12, 335);
            this.groupBoxCompass.Name = "groupBoxCompass";
            this.groupBoxCompass.Size = new System.Drawing.Size(243, 80);
            this.groupBoxCompass.TabIndex = 9;
            this.groupBoxCompass.TabStop = false;
            this.groupBoxCompass.Text = "Compass";
            // 
            // trackCompassValue
            // 
            this.trackCompassValue.Location = new System.Drawing.Point(7, 29);
            this.trackCompassValue.Maximum = 360;
            this.trackCompassValue.Name = "trackCompassValue";
            this.trackCompassValue.Size = new System.Drawing.Size(228, 45);
            this.trackCompassValue.TabIndex = 6;
            this.trackCompassValue.TickFrequency = 36;
            this.trackCompassValue.Scroll += new System.EventHandler(this.trackCompassValue_Scroll);
            // 
            // groupBoxAirSpeed
            // 
            this.groupBoxAirSpeed.Controls.Add(this.labelAirSpeedMaxValue);
            this.groupBoxAirSpeed.Controls.Add(this.labelAirSpeedMinValue);
            this.groupBoxAirSpeed.Controls.Add(this.labelAirSpeedMinimum);
            this.groupBoxAirSpeed.Controls.Add(this.trackAirSpeedValue);
            this.groupBoxAirSpeed.Controls.Add(this.trackAirSpeedMax);
            this.groupBoxAirSpeed.Controls.Add(this.labelAirSpeedMaximum);
            this.groupBoxAirSpeed.Controls.Add(this.trackAirSpeedMin);
            this.groupBoxAirSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAirSpeed.Location = new System.Drawing.Point(12, 173);
            this.groupBoxAirSpeed.Name = "groupBoxAirSpeed";
            this.groupBoxAirSpeed.Size = new System.Drawing.Size(243, 155);
            this.groupBoxAirSpeed.TabIndex = 8;
            this.groupBoxAirSpeed.TabStop = false;
            this.groupBoxAirSpeed.Text = "Air Speed";
            // 
            // labelAirSpeedMaxValue
            // 
            this.labelAirSpeedMaxValue.Location = new System.Drawing.Point(196, 131);
            this.labelAirSpeedMaxValue.Name = "labelAirSpeedMaxValue";
            this.labelAirSpeedMaxValue.Size = new System.Drawing.Size(31, 13);
            this.labelAirSpeedMaxValue.TabIndex = 7;
            this.labelAirSpeedMaxValue.Text = "100";
            this.labelAirSpeedMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAirSpeedMinValue
            // 
            this.labelAirSpeedMinValue.AutoSize = true;
            this.labelAirSpeedMinValue.Location = new System.Drawing.Point(17, 131);
            this.labelAirSpeedMinValue.Name = "labelAirSpeedMinValue";
            this.labelAirSpeedMinValue.Size = new System.Drawing.Size(13, 13);
            this.labelAirSpeedMinValue.TabIndex = 6;
            this.labelAirSpeedMinValue.Text = "0";
            // 
            // labelAirSpeedMinimum
            // 
            this.labelAirSpeedMinimum.AutoSize = true;
            this.labelAirSpeedMinimum.Location = new System.Drawing.Point(6, 30);
            this.labelAirSpeedMinimum.Name = "labelAirSpeedMinimum";
            this.labelAirSpeedMinimum.Size = new System.Drawing.Size(48, 13);
            this.labelAirSpeedMinimum.TabIndex = 1;
            this.labelAirSpeedMinimum.Text = "Minimum";
            // 
            // trackAirSpeedValue
            // 
            this.trackAirSpeedValue.Location = new System.Drawing.Point(9, 99);
            this.trackAirSpeedValue.Maximum = 100;
            this.trackAirSpeedValue.Name = "trackAirSpeedValue";
            this.trackAirSpeedValue.Size = new System.Drawing.Size(228, 45);
            this.trackAirSpeedValue.TabIndex = 5;
            this.trackAirSpeedValue.TickFrequency = 5;
            this.trackAirSpeedValue.Scroll += new System.EventHandler(this.trackAirSpeedValue_Scroll);
            // 
            // trackAirSpeedMax
            // 
            this.trackAirSpeedMax.LargeChange = 10;
            this.trackAirSpeedMax.Location = new System.Drawing.Point(75, 67);
            this.trackAirSpeedMax.Maximum = 100;
            this.trackAirSpeedMax.Name = "trackAirSpeedMax";
            this.trackAirSpeedMax.Size = new System.Drawing.Size(162, 45);
            this.trackAirSpeedMax.SmallChange = 10;
            this.trackAirSpeedMax.TabIndex = 4;
            this.trackAirSpeedMax.TickFrequency = 10;
            this.trackAirSpeedMax.Value = 100;
            this.trackAirSpeedMax.Scroll += new System.EventHandler(this.trackAirSpeedMax_Scroll);
            // 
            // labelAirSpeedMaximum
            // 
            this.labelAirSpeedMaximum.AutoSize = true;
            this.labelAirSpeedMaximum.Location = new System.Drawing.Point(6, 67);
            this.labelAirSpeedMaximum.Name = "labelAirSpeedMaximum";
            this.labelAirSpeedMaximum.Size = new System.Drawing.Size(51, 13);
            this.labelAirSpeedMaximum.TabIndex = 3;
            this.labelAirSpeedMaximum.Text = "Maximum";
            // 
            // trackAirSpeedMin
            // 
            this.trackAirSpeedMin.LargeChange = 10;
            this.trackAirSpeedMin.Location = new System.Drawing.Point(75, 30);
            this.trackAirSpeedMin.Maximum = 100;
            this.trackAirSpeedMin.Name = "trackAirSpeedMin";
            this.trackAirSpeedMin.Size = new System.Drawing.Size(162, 45);
            this.trackAirSpeedMin.SmallChange = 10;
            this.trackAirSpeedMin.TabIndex = 2;
            this.trackAirSpeedMin.TickFrequency = 10;
            this.trackAirSpeedMin.Scroll += new System.EventHandler(this.trackAirSpeedMin_Scroll);
            // 
            // groupBoxAltitude
            // 
            this.groupBoxAltitude.Controls.Add(this.labelAltitudeMaxValue);
            this.groupBoxAltitude.Controls.Add(this.labelAltitudeMinValue);
            this.groupBoxAltitude.Controls.Add(this.labelAltitudeMinimum);
            this.groupBoxAltitude.Controls.Add(this.trackAltitudeValue);
            this.groupBoxAltitude.Controls.Add(this.trackAltitudeMax);
            this.groupBoxAltitude.Controls.Add(this.labelAltitudeMaximum);
            this.groupBoxAltitude.Controls.Add(this.trackAltitudeMin);
            this.groupBoxAltitude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAltitude.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAltitude.Name = "groupBoxAltitude";
            this.groupBoxAltitude.Size = new System.Drawing.Size(243, 155);
            this.groupBoxAltitude.TabIndex = 6;
            this.groupBoxAltitude.TabStop = false;
            this.groupBoxAltitude.Text = "Altitude";
            // 
            // labelAltitudeMaxValue
            // 
            this.labelAltitudeMaxValue.Location = new System.Drawing.Point(196, 131);
            this.labelAltitudeMaxValue.Name = "labelAltitudeMaxValue";
            this.labelAltitudeMaxValue.Size = new System.Drawing.Size(31, 13);
            this.labelAltitudeMaxValue.TabIndex = 7;
            this.labelAltitudeMaxValue.Text = "1000";
            this.labelAltitudeMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAltitudeMinValue
            // 
            this.labelAltitudeMinValue.AutoSize = true;
            this.labelAltitudeMinValue.Location = new System.Drawing.Point(17, 131);
            this.labelAltitudeMinValue.Name = "labelAltitudeMinValue";
            this.labelAltitudeMinValue.Size = new System.Drawing.Size(13, 13);
            this.labelAltitudeMinValue.TabIndex = 6;
            this.labelAltitudeMinValue.Text = "0";
            // 
            // labelAltitudeMinimum
            // 
            this.labelAltitudeMinimum.AutoSize = true;
            this.labelAltitudeMinimum.Location = new System.Drawing.Point(6, 30);
            this.labelAltitudeMinimum.Name = "labelAltitudeMinimum";
            this.labelAltitudeMinimum.Size = new System.Drawing.Size(48, 13);
            this.labelAltitudeMinimum.TabIndex = 1;
            this.labelAltitudeMinimum.Text = "Minimum";
            // 
            // trackAltitudeValue
            // 
            this.trackAltitudeValue.Location = new System.Drawing.Point(9, 99);
            this.trackAltitudeValue.Maximum = 1000;
            this.trackAltitudeValue.Name = "trackAltitudeValue";
            this.trackAltitudeValue.Size = new System.Drawing.Size(228, 45);
            this.trackAltitudeValue.TabIndex = 5;
            this.trackAltitudeValue.TickFrequency = 50;
            this.trackAltitudeValue.Scroll += new System.EventHandler(this.trackAltitudeValue_Scroll);
            // 
            // trackAltitudeMax
            // 
            this.trackAltitudeMax.LargeChange = 10;
            this.trackAltitudeMax.Location = new System.Drawing.Point(75, 67);
            this.trackAltitudeMax.Maximum = 1000;
            this.trackAltitudeMax.Name = "trackAltitudeMax";
            this.trackAltitudeMax.Size = new System.Drawing.Size(162, 45);
            this.trackAltitudeMax.SmallChange = 10;
            this.trackAltitudeMax.TabIndex = 4;
            this.trackAltitudeMax.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackAltitudeMax.Value = 1000;
            this.trackAltitudeMax.Scroll += new System.EventHandler(this.trackAltitudeMax_Scroll);
            // 
            // labelAltitudeMaximum
            // 
            this.labelAltitudeMaximum.AutoSize = true;
            this.labelAltitudeMaximum.Location = new System.Drawing.Point(6, 67);
            this.labelAltitudeMaximum.Name = "labelAltitudeMaximum";
            this.labelAltitudeMaximum.Size = new System.Drawing.Size(51, 13);
            this.labelAltitudeMaximum.TabIndex = 3;
            this.labelAltitudeMaximum.Text = "Maximum";
            // 
            // trackAltitudeMin
            // 
            this.trackAltitudeMin.LargeChange = 10;
            this.trackAltitudeMin.Location = new System.Drawing.Point(75, 30);
            this.trackAltitudeMin.Maximum = 1000;
            this.trackAltitudeMin.Name = "trackAltitudeMin";
            this.trackAltitudeMin.Size = new System.Drawing.Size(162, 45);
            this.trackAltitudeMin.SmallChange = 10;
            this.trackAltitudeMin.TabIndex = 2;
            this.trackAltitudeMin.TickFrequency = 100;
            this.trackAltitudeMin.Scroll += new System.EventHandler(this.trackAltitudeMin_Scroll);
            // 
            // pfdControl1
            // 
            this.pfdControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pfdControl1.Location = new System.Drawing.Point(0, 0);
            this.pfdControl1.Name = "pfdControl1";
            this.pfdControl1.Size = new System.Drawing.Size(498, 591);
            this.pfdControl1.TabIndex = 0;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 591);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PFD Demo";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxHorizon.ResumeLayout(false);
            this.groupBoxHorizon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHorizonRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackHorizonPitch)).EndInit();
            this.groupBoxCompass.ResumeLayout(false);
            this.groupBoxCompass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCompassValue)).EndInit();
            this.groupBoxAirSpeed.ResumeLayout(false);
            this.groupBoxAirSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAirSpeedMin)).EndInit();
            this.groupBoxAltitude.ResumeLayout(false);
            this.groupBoxAltitude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAltitudeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private PrimaryFlightDisplay.PFDControl pfdControl1;
        private System.Windows.Forms.TrackBar trackAltitudeMin;
        private System.Windows.Forms.Label labelAltitudeMinimum;
        private System.Windows.Forms.TrackBar trackAltitudeMax;
        private System.Windows.Forms.Label labelAltitudeMaximum;
        private System.Windows.Forms.GroupBox groupBoxAltitude;
        private System.Windows.Forms.TrackBar trackAltitudeValue;
        private System.Windows.Forms.Label labelAltitudeMaxValue;
        private System.Windows.Forms.Label labelAltitudeMinValue;
        private System.Windows.Forms.GroupBox groupBoxAirSpeed;
        private System.Windows.Forms.Label labelAirSpeedMaxValue;
        private System.Windows.Forms.Label labelAirSpeedMinValue;
        private System.Windows.Forms.Label labelAirSpeedMinimum;
        private System.Windows.Forms.TrackBar trackAirSpeedValue;
        private System.Windows.Forms.TrackBar trackAirSpeedMax;
        private System.Windows.Forms.Label labelAirSpeedMaximum;
        private System.Windows.Forms.TrackBar trackAirSpeedMin;
        private System.Windows.Forms.GroupBox groupBoxCompass;
        private System.Windows.Forms.TrackBar trackCompassValue;
        private System.Windows.Forms.GroupBox groupBoxHorizon;
        private System.Windows.Forms.TrackBar trackHorizonPitch;
        private System.Windows.Forms.TrackBar trackHorizonRoll;
    }
}