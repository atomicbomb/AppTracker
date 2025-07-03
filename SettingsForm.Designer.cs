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
            grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPollingInterval).BeginInit();
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
            btnSave.Location = new Point(216, 110);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(297, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 156);
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
            ResumeLayout(false);
        }

        #endregion
    }
}
