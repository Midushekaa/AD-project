namespace Management_Sytem
{
    partial class AdminDashboard
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

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnMeter = new System.Windows.Forms.Button();
            this.btnMeterReading = new System.Windows.Forms.Button();
            this.btnTariffPlan = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnNotification = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(34, 76, 152);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Name = "panelTop";
            // 
            // label1
            // 
            this.label1.Text = "Admin Dashboard";
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.AutoSize = true;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(0, 70, 160);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 200;
            this.panelSidebar.Controls.Add(this.btnCustomer);
            this.panelSidebar.Controls.Add(this.btnMeter);
            this.panelSidebar.Controls.Add(this.btnMeterReading);
            this.panelSidebar.Controls.Add(this.btnTariffPlan);
            this.panelSidebar.Controls.Add(this.btnBill);
            this.panelSidebar.Controls.Add(this.btnPayment);
            this.panelSidebar.Controls.Add(this.btnNotification);
            this.panelSidebar.Controls.Add(this.btnLogout);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Text = "Manage Customers";
            this.btnCustomer.Height = 50;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnMeter
            // 
            this.btnMeter.Text = "Manage Meters";
            this.btnMeter.Height = 50;
            this.btnMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMeter.ForeColor = System.Drawing.Color.White;
            this.btnMeter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeter.Click += new System.EventHandler(this.btnMeter_Click);
            // 
            // btnMeterReading
            // 
            this.btnMeterReading.Text = "Meter Readings";
            this.btnMeterReading.Height = 50;
            this.btnMeterReading.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMeterReading.ForeColor = System.Drawing.Color.White;
            this.btnMeterReading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeterReading.Click += new System.EventHandler(this.btnMeterReading_Click);
            // 
            // btnTariffPlan
            // 
            this.btnTariffPlan.Text = "Tariff Plans";
            this.btnTariffPlan.Height = 50;
            this.btnTariffPlan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTariffPlan.ForeColor = System.Drawing.Color.White;
            this.btnTariffPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTariffPlan.Click += new System.EventHandler(this.btnTariffPlan_Click);
            // 
            // btnBill
            // 
            this.btnBill.Text = "Bills";
            this.btnBill.Height = 50;
            this.btnBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBill.ForeColor = System.Drawing.Color.White;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Text = "Payments";
            this.btnPayment.Height = 50;
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.Text = "Notifications";
            this.btnNotification.Height = 50;
            this.btnNotification.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNotification.ForeColor = System.Drawing.Color.White;
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Text = "Logout";
            this.btnLogout.Height = 50;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.BackColor = System.Drawing.Color.White;
            // 
            // AdminDashboard
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelTop);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.MaximizeBox = false;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnMeter;
        private System.Windows.Forms.Button btnMeterReading;
        private System.Windows.Forms.Button btnTariffPlan;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.Button btnLogout;
    }
}
