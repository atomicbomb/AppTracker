namespace AppTracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblStatus;
        private Label lblCurrentApp;
        private Label lblCurrentWindow;
        private Label lblLastUpdate;
        private Button btnViewSummary;
        private Button btnSettings;
        private Button btnMinimize;
        private GroupBox grpCurrentActivity;
        private GroupBox grpControls;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpCurrentActivity = new GroupBox();
            lblCurrentApp = new Label();
            lblCurrentWindow = new Label();
            lblLastUpdate = new Label();
            grpControls = new GroupBox();
            btnViewSummary = new Button();
            btnSettings = new Button();
            btnMinimize = new Button();
            lblStatus = new Label();
            grpCurrentActivity.SuspendLayout();
            grpControls.SuspendLayout();
            SuspendLayout();
            // 
            // grpCurrentActivity
            // 
            grpCurrentActivity.Controls.Add(lblCurrentApp);
            grpCurrentActivity.Controls.Add(lblCurrentWindow);
            grpCurrentActivity.Controls.Add(lblLastUpdate);
            grpCurrentActivity.Location = new Point(12, 12);
            grpCurrentActivity.Name = "grpCurrentActivity";
            grpCurrentActivity.Size = new Size(460, 120);
            grpCurrentActivity.TabIndex = 0;
            grpCurrentActivity.TabStop = false;
            grpCurrentActivity.Text = "Current Activity";
            // 
            // lblCurrentApp
            // 
            lblCurrentApp.AutoSize = true;
            lblCurrentApp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentApp.Location = new Point(15, 25);
            lblCurrentApp.Name = "lblCurrentApp";
            lblCurrentApp.Size = new Size(96, 15);
            lblCurrentApp.TabIndex = 0;
            lblCurrentApp.Text = "No application";
            // 
            // lblCurrentWindow
            // 
            lblCurrentWindow.Location = new Point(15, 50);
            lblCurrentWindow.Name = "lblCurrentWindow";
            lblCurrentWindow.Size = new Size(430, 40);
            lblCurrentWindow.TabIndex = 1;
            lblCurrentWindow.Text = "No window";
            // 
            // lblLastUpdate
            // 
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblLastUpdate.Location = new Point(15, 95);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(91, 13);
            lblLastUpdate.TabIndex = 2;
            lblLastUpdate.Text = "Never updated";
            // 
            // grpControls
            // 
            grpControls.Controls.Add(btnViewSummary);
            grpControls.Controls.Add(btnSettings);
            grpControls.Controls.Add(btnMinimize);
            grpControls.Location = new Point(12, 145);
            grpControls.Name = "grpControls";
            grpControls.Size = new Size(460, 80);
            grpControls.TabIndex = 1;
            grpControls.TabStop = false;
            grpControls.Text = "Controls";
            // 
            // btnViewSummary
            // 
            btnViewSummary.Location = new Point(15, 30);
            btnViewSummary.Name = "btnViewSummary";
            btnViewSummary.Size = new Size(120, 30);
            btnViewSummary.TabIndex = 0;
            btnViewSummary.Text = "View Summary";
            btnViewSummary.UseVisualStyleBackColor = true;
            btnViewSummary.Click += btnViewSummary_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(150, 30);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(120, 30);
            btnSettings.TabIndex = 1;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Location = new Point(285, 30);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(120, 30);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "Minimize to Tray";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Ready";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 271);
            Controls.Add(lblStatus);
            Controls.Add(grpControls);
            Controls.Add(grpCurrentActivity);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppTracker";
            grpCurrentActivity.ResumeLayout(false);
            grpCurrentActivity.PerformLayout();
            grpControls.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
