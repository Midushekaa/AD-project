namespace Management_Sytem
{
    partial class CustomerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMeterUsage;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnMeterUsage = new System.Windows.Forms.Button();
            this.btnBills = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ========================
            // Sidebar Panel
            // ========================
            this.sidebarPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Width = 150;

            // ========================
            // Buttons
            // ========================
            int btnTop = 20;
            System.Windows.Forms.Button[] buttons = new System.Windows.Forms.Button[] {
                btnDashboard, btnProfile, btnMeterUsage, btnBills,
                btnPayments, btnNotifications, btnSettings, btnLogout
            };
            string[] btnNames = new string[] {
                "Dashboard", "Profile", "Meter & Usage", "Bills",
                "Payments", "Notifications", "Settings", "Logout"
            };

            foreach (var button in buttons)
            {
                button.Width = 130;
                button.Height = 40;
                button.Left = 10;
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.BackColor = System.Drawing.Color.LightSlateGray;
                button.ForeColor = System.Drawing.Color.White;
            }

            btnDashboard.Text = btnNames[0]; btnDashboard.Top = btnTop; btnTop += 50;
            btnProfile.Text = btnNames[1]; btnProfile.Top = btnTop; btnTop += 50;
            btnMeterUsage.Text = btnNames[2]; btnMeterUsage.Top = btnTop; btnTop += 50;
            btnBills.Text = btnNames[3]; btnBills.Top = btnTop; btnTop += 50;
            btnPayments.Text = btnNames[4]; btnPayments.Top = btnTop; btnTop += 50;
            btnNotifications.Text = btnNames[5]; btnNotifications.Top = btnTop; btnTop += 50;
            btnSettings.Text = btnNames[6]; btnSettings.Top = btnTop; btnTop += 50;
            btnLogout.Text = btnNames[7]; btnLogout.Top = btnTop;

            // Add buttons to sidebar
            this.sidebarPanel.Controls.AddRange(buttons);

            // ========================
            // Content Panel
            // ========================
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.BackColor = System.Drawing.Color.WhiteSmoke;

            // ========================
            // Title Label
            // ========================
            this.lblTitle.Text = "Customer Dashboard";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Top = 10;
            this.lblTitle.Left = 160;

            // ========================
            // Form
            // ========================
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.lblTitle);
            this.Text = "Customer Dashboard";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
