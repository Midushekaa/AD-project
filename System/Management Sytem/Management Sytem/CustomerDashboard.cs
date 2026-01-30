using System;
using System.Windows.Forms;
using System.Drawing;

namespace Management_Sytem
{
    public partial class CustomerDashboard : Form
    {
        private int AccountId;

        public CustomerDashboard(int accountId)
        {
            AccountId = accountId;
            InitializeComponent();

            // Attach click events
            btnProfile.Click += BtnProfile_Click;
            btnDashboard.Click += BtnDashboard_Click;
            btnBills.Click += BtnBills_Click;
            btnPayments.Click += BtnPayments_Click;
            btnNotifications.Click += BtnNotifications_Click;
            btnSettings.Click += BtnSettings_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        // ===========================
        // Button Click Events
        // ===========================
        private void BtnProfile_Click(object sender, EventArgs e)
        {
            // Clear existing content
            contentPanel.Controls.Clear();

            // Create profile page and show
            ProfileControl profile = new ProfileControl(AccountId);
            profile.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(profile);
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            Label lbl = new Label
            {
                Text = "Welcome to your Dashboard",
                AutoSize = true,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Top = 50,
                Left = 50
            };
            contentPanel.Controls.Add(lbl);
        }

        private void BtnBills_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            BillsControl bills = new BillsControl(AccountId);
            bills.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(bills);
        }

        private void BtnPayments_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            PaymentsControl payments = new PaymentsControl(AccountId);
            payments.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(payments);
        }

        private void BtnNotifications_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            NotificationsControl notifications = new NotificationsControl(AccountId);
            notifications.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(notifications);
        }



        private void BtnSettings_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            Label lbl = new Label
            {
                Text = "Settings Page (Under Construction)",
                AutoSize = true,
                Top = 50,
                Left = 50
            };
            contentPanel.Controls.Add(lbl);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // or show login form
        }
    }

    // ===========================
    // UserControls
    // ===========================
    public class ProfileControl : UserControl
    {
        private int AccountId;

        public ProfileControl(int accountId)
        {
            AccountId = accountId;
            this.BackColor = Color.LightBlue;

            Label lbl = new Label
            {
                Text = $"Profile Page for Account ID: {AccountId}",
                AutoSize = true,
                Top = 50,
                Left = 50,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            this.Controls.Add(lbl);

            // You can add more controls here like TextBoxes for Name, Address, Phone etc.
        }
    }

    public class BillsControl : UserControl
    {
        private int AccountId;

        public BillsControl(int accountId)
        {
            AccountId = accountId;
            this.BackColor = Color.LightGreen;
            Label lbl = new Label { Text = $"Bills Page for Account ID: {AccountId}", AutoSize = true, Top = 50, Left = 50 };
            this.Controls.Add(lbl);
        }
    }

    public class PaymentsControl : UserControl
    {
        private int AccountId;

        public PaymentsControl(int accountId)
        {
            AccountId = accountId;
            this.BackColor = Color.LightYellow;
            Label lbl = new Label { Text = $"Payments Page for Account ID: {AccountId}", AutoSize = true, Top = 50, Left = 50 };
            this.Controls.Add(lbl);
        }
    }

    public class NotificationsControl : UserControl
    {
        private int AccountId;

        public NotificationsControl(int accountId)
        {
            AccountId = accountId;
            this.BackColor = Color.LightCoral;
            Label lbl = new Label { Text = $"Notifications Page for Account ID: {AccountId}", AutoSize = true, Top = 50, Left = 50 };
            this.Controls.Add(lbl);
        }
    }
}
