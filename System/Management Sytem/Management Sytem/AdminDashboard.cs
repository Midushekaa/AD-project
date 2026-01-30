using System;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class AdminDashboard : Form
    {
        private Form activeForm = null; // To track the currently open child form

        public AdminDashboard()
        {
            InitializeComponent();
        }

        // ============================
        // Open child form inside panelMain
        // ============================
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ============================
        // Button Clicks
        // ============================
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer customerForm = new Customer();
            OpenChildForm(customerForm);
        }

        private void btnMeter_Click(object sender, EventArgs e)
        {
            Meter meterForm = new Meter();
            OpenChildForm(meterForm);
        }

        private void btnMeterReading_Click(object sender, EventArgs e)
        {
            Meter_Reading meterReadingForm = new Meter_Reading();
            OpenChildForm(meterReadingForm);
        }

        private void btnTariffPlan_Click(object sender, EventArgs e)
        {
            Traiff_Plan tariffForm = new Traiff_Plan();
            OpenChildForm(tariffForm);
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Bill billForm = new Bill();
            OpenChildForm(billForm);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment paymentForm = new Payment();
            OpenChildForm(paymentForm);
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            Notification notificationForm = new Notification();
            OpenChildForm(notificationForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            // Optionally show login form here
        }
    }
}
