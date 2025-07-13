namespace AppTracker
{
    partial class SummaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblDate;
        private ListView listViewSummary;
        private Label lblTotalTime;
        private Button btnClose;
        private Button btnPreviousDay;
        private Button btnNextDay;
        private Button btnExportCsv;
        private ColumnHeader colApplication;
        private ColumnHeader colTime;
        private ColumnHeader colSessions;
        private ColumnHeader colPercentage;

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
            lblDate = new Label();
            listViewSummary = new ListView();
            colApplication = new ColumnHeader();
            colTime = new ColumnHeader();
            colSessions = new ColumnHeader();
            colPercentage = new ColumnHeader();
            lblTotalTime = new Label();
            btnClose = new Button();
            btnPreviousDay = new Button();
            btnNextDay = new Button();
            btnExportCsv = new Button();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDate.Location = new Point(12, 15);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(560, 25);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listViewSummary
            // 
            listViewSummary.Columns.AddRange(new ColumnHeader[] { colApplication, colTime, colSessions, colPercentage });
            listViewSummary.FullRowSelect = true;
            listViewSummary.GridLines = true;
            listViewSummary.Location = new Point(12, 50);
            listViewSummary.Name = "listViewSummary";
            listViewSummary.Size = new Size(560, 300);
            listViewSummary.TabIndex = 1;
            listViewSummary.UseCompatibleStateImageBehavior = false;
            listViewSummary.View = View.Details;
            // 
            // colApplication
            // 
            colApplication.Text = "Application";
            colApplication.Width = 200;
            // 
            // colTime
            // 
            colTime.Text = "Time Used";
            colTime.Width = 120;
            // 
            // colSessions
            // 
            colSessions.Text = "Sessions";
            colSessions.Width = 80;
            // 
            // colPercentage
            // 
            colPercentage.Text = "Percentage";
            colPercentage.Width = 100;
            // 
            // lblTotalTime
            // 
            lblTotalTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalTime.Location = new Point(12, 365);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(560, 20);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "Total time: 0h 0m";
            lblTotalTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPreviousDay
            // 
            btnPreviousDay.Location = new Point(12, 400);
            btnPreviousDay.Name = "btnPreviousDay";
            btnPreviousDay.Size = new Size(100, 30);
            btnPreviousDay.TabIndex = 3;
            btnPreviousDay.Text = "← Previous Day";
            btnPreviousDay.UseVisualStyleBackColor = true;
            btnPreviousDay.Click += btnPreviousDay_Click;
            // 
            // btnNextDay
            // 
            btnNextDay.Location = new Point(472, 400);
            btnNextDay.Name = "btnNextDay";
            btnNextDay.Size = new Size(100, 30);
            btnNextDay.TabIndex = 4;
            btnNextDay.Text = "Next Day →";
            btnNextDay.UseVisualStyleBackColor = true;
            btnNextDay.Click += btnNextDay_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(340, 400);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 30);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.Location = new Point(118, 400);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(130, 30);
            btnExportCsv.TabIndex = 6;
            btnExportCsv.Text = "Export to CSV";
            btnExportCsv.UseVisualStyleBackColor = true;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // SummaryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 451);
            Controls.Add(btnExportCsv);
            Controls.Add(btnClose);
            Controls.Add(btnNextDay);
            Controls.Add(btnPreviousDay);
            Controls.Add(lblTotalTime);
            Controls.Add(listViewSummary);
            Controls.Add(lblDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SummaryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usage Summary";
            ResumeLayout(false);
        }

        #endregion
    }
}
