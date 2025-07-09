namespace AppTracker
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblPollingInterval;
        private NumericUpDown numPollingInterval;
        private Label lblSeconds;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox grpSettings;
        private GroupBox grpTrackingTime;
        private CheckBox chkEnableTimeTracking;
        private DateTimePicker dtpStartTime;
        private DateTimePicker dtpEndTime;
        private Label lblStartTime;
        private Label lblEndTime;

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
            grpSettings = new GroupBox();
            lblPollingInterval = new Label();
            numPollingInterval = new NumericUpDown();
            lblSeconds = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            grpTrackingTime = new GroupBox();
            chkEnableTimeTracking = new CheckBox();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            lblStartTime = new Label();
            lblEndTime = new Label();
            grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPollingInterval).BeginInit();
            grpTrackingTime.SuspendLayout();
            SuspendLayout();
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(lblPollingInterval);
            grpSettings.Controls.Add(numPollingInterval);
            grpSettings.Controls.Add(lblSeconds);
            grpSettings.Location = new Point(12, 12);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(360, 80);
            grpSettings.TabIndex = 0;
            grpSettings.TabStop = false;
            grpSettings.Text = "Polling Settings";
            // 
            // lblPollingInterval
            // 
            lblPollingInterval.AutoSize = true;
            lblPollingInterval.Location = new Point(15, 35);
            lblPollingInterval.Name = "lblPollingInterval";
            lblPollingInterval.Size = new Size(88, 15);
            lblPollingInterval.TabIndex = 0;
            lblPollingInterval.Text = "Polling Interval:";
            // 
            // numPollingInterval
            // 
            numPollingInterval.Location = new Point(110, 33);
            numPollingInterval.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numPollingInterval.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numPollingInterval.Name = "numPollingInterval";
            numPollingInterval.Size = new Size(80, 23);
            numPollingInterval.TabIndex = 1;
            numPollingInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new Point(200, 35);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(51, 15);
            lblSeconds.TabIndex = 2;
            lblSeconds.Text = "seconds";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(216, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(297, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // grpTrackingTime
            // 
            grpTrackingTime.Controls.Add(chkEnableTimeTracking);
            grpTrackingTime.Controls.Add(dtpStartTime);
            grpTrackingTime.Controls.Add(dtpEndTime);
            grpTrackingTime.Controls.Add(lblStartTime);
            grpTrackingTime.Controls.Add(lblEndTime);
            grpTrackingTime.Location = new Point(12, 98);
            grpTrackingTime.Name = "grpTrackingTime";
            grpTrackingTime.Size = new Size(360, 120);
            grpTrackingTime.TabIndex = 3;
            grpTrackingTime.TabStop = false;
            grpTrackingTime.Text = "Tracking Time";
            // 
            // chkEnableTimeTracking
            // 
            chkEnableTimeTracking.AutoSize = true;
            chkEnableTimeTracking.Location = new Point(15, 30);
            chkEnableTimeTracking.Name = "chkEnableTimeTracking";
            chkEnableTimeTracking.Size = new Size(180, 19);
            chkEnableTimeTracking.TabIndex = 0;
            chkEnableTimeTracking.Text = "Enable time-based tracking";
            chkEnableTimeTracking.UseVisualStyleBackColor = true;
            chkEnableTimeTracking.CheckedChanged += chkEnableTimeTracking_CheckedChanged;
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(80, 60);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(100, 23);
            dtpStartTime.TabIndex = 1;
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(240, 60);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(100, 23);
            dtpEndTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(15, 65);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(60, 15);
            lblStartTime.TabIndex = 3;
            lblStartTime.Text = "Start Time:";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(180, 65);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(56, 15);
            lblEndTime.TabIndex = 4;
            lblEndTime.Text = "End Time:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 271);
            Controls.Add(grpTrackingTime);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(grpSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPollingInterval).EndInit();
            grpTrackingTime.ResumeLayout(false);
            grpTrackingTime.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
