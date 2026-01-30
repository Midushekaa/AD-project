using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Management_Sytem.Sub_class;

namespace Management_Sytem
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            LoadNotifications();
        }

        // Load all notifications into the DataGridView
        private void LoadNotifications()
        {
            string query = "SELECT * FROM NOTIFICATION";
            mainClass.LoadData(query, dgvNotifications);
        }

        // Save new notification
        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = @"INSERT INTO NOTIFICATION (Account_id_fk, Bill_id_fk, Title, Message)
                             VALUES (@AccountId, @BillId, @Title, @Message)";

            SqlParameter[] parameters = {
                new SqlParameter("@AccountId", txtAccountId.Text),
                new SqlParameter("@BillId", string.IsNullOrEmpty(txtBillId.Text) ? (object)DBNull.Value : txtBillId.Text),
                new SqlParameter("@Title", txtTitle.Text),
                new SqlParameter("@Message", txtMessage.Text)
            };

            if (mainClass.InsertData(query, "Notification Saved!", "Failed to Save Notification", parameters))
                LoadNotifications();
        }

        // Update existing notification
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE NOTIFICATION
                             SET Account_id_fk=@AccountId, Bill_id_fk=@BillId, Title=@Title, Message=@Message
                             WHERE Notification_id_pk=@Id";

            SqlParameter[] parameters = {
                new SqlParameter("@AccountId", txtAccountId.Text),
                new SqlParameter("@BillId", string.IsNullOrEmpty(txtBillId.Text) ? (object)DBNull.Value : txtBillId.Text),
                new SqlParameter("@Title", txtTitle.Text),
                new SqlParameter("@Message", txtMessage.Text),
                new SqlParameter("@Id", txtNotificationId.Text)
            };

            if (mainClass.UpdateData(query, parameters))
                LoadNotifications();
        }

        // Delete notification
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NOTIFICATION WHERE Notification_id_pk=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", txtNotificationId.Text)
            };

            if (mainClass.DeleteData(query, parameters))
                LoadNotifications();
        }

        // Fill form when a row is selected
        private void dgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNotificationId.Text = dgvNotifications.Rows[e.RowIndex].Cells["Notification_id_pk"].Value.ToString();
                txtAccountId.Text = dgvNotifications.Rows[e.RowIndex].Cells["Account_id_fk"].Value.ToString();
                txtBillId.Text = dgvNotifications.Rows[e.RowIndex].Cells["Bill_id_fk"].Value?.ToString();
                txtTitle.Text = dgvNotifications.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                txtMessage.Text = dgvNotifications.Rows[e.RowIndex].Cells["Message"].Value.ToString();
            }
        }

        // Clear all input fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNotificationId.Clear();
            txtAccountId.Clear();
            txtBillId.Clear();
            txtTitle.Clear();
            txtMessage.Clear();
        }
    }
}
