using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            LoadGrid();
        }

        // ===========================
        // Load DataGridView
        // ===========================
        private void LoadGrid()
        {
            try
            {
                string sql = @"SELECT Payment_Id_pk, Account_Id_fk, Bill_Id_fk, PaymentDate, AmountPaid, PaymentStatus 
                               FROM PAYMENT";
                mainClass.LoadData(sql, dataGridView1); // Ensure mainClass.LoadData is working
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===========================
        // Clear all input fields
        // ===========================
        private void ClearFields()
        {
            PaidAmountBox.Clear();
            PatmentStatus_Combo.Text = "-- none --";
            PaymentDate.Value = DateTime.Today;
        }

        // ===========================
        // Save Payment
        // ===========================
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(PaidAmountBox.Text.Trim(), out amount))
            {
                MessageBox.Show("Invalid Paid Amount! Enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int accountId = 1; // TODO: replace with actual selected account
            int billId = 1;    // TODO: replace with actual selected bill

            string sql = @"INSERT INTO PAYMENT (Account_Id_fk, Bill_Id_fk, PaymentDate, AmountPaid, PaymentStatus)
                           VALUES (@AccountId, @BillId, @PaymentDate, @AmountPaid, @PaymentStatus)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@AccountId", accountId),
                new SqlParameter("@BillId", billId),
                new SqlParameter("@PaymentDate", PaymentDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@AmountPaid", amount),
                new SqlParameter("@PaymentStatus", PatmentStatus_Combo.Text)
            };

            if (mainClass.InsertData(sql, "Payment saved successfully", "Failed to save payment", parameters))
            {
                LoadGrid();
                ClearFields();
            }
        }

        // ===========================
        // Update Payment
        // ===========================
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int paymentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Payment_Id_pk"].Value);

                decimal amount;
                if (!decimal.TryParse(PaidAmountBox.Text.Trim(), out amount))
                {
                    MessageBox.Show("Invalid Paid Amount! Enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int accountId = 1; // TODO: replace with actual selected account
                int billId = 1;    // TODO: replace with actual selected bill

                string sql = @"UPDATE PAYMENT 
                               SET Account_Id_fk=@AccountId, Bill_Id_fk=@BillId, PaymentDate=@PaymentDate, AmountPaid=@AmountPaid, PaymentStatus=@PaymentStatus
                               WHERE Payment_Id_pk=@PaymentId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@AccountId", accountId),
                    new SqlParameter("@BillId", billId),
                    new SqlParameter("@PaymentDate", PaymentDate.Value.ToString("yyyy-MM-dd")),
                    new SqlParameter("@AmountPaid", amount),
                    new SqlParameter("@PaymentStatus", PatmentStatus_Combo.Text),
                    new SqlParameter("@PaymentId", paymentId)
                };

                if (mainClass.UpdateData(sql, parameters))
                {
                    LoadGrid();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===========================
        // Delete Payment
        // ===========================
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int paymentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Payment_Id_pk"].Value);

                string sql = "DELETE FROM PAYMENT WHERE Payment_Id_pk=@PaymentId";
                SqlParameter[] parameters = { new SqlParameter("@PaymentId", paymentId) };

                if (mainClass.DeleteData(sql, parameters))
                {
                    LoadGrid();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PaymentDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                PaidAmountBox.Text = row.Cells["AmountPaid"].Value.ToString();
                PaymentDate.Value = Convert.ToDateTime(row.Cells["PaymentDate"].Value);
                PatmentStatus_Combo.Text = row.Cells["PaymentStatus"].Value.ToString();
            }
        }
    }
}
