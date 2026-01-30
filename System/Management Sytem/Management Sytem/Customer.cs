using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            string sql = "SELECT Customer_Id_PK, Name, NIC, Phone_No, Address FROM Customer";
            mainClass.LoadData(sql, dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearFields()
        {
            NameBox.Clear();
            NICBox.Clear();
            MobileBox.Clear();
            AddressBox.Clear();
            NameBox.Focus();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Customer (Name, NIC, Phone_No, Address)
                           VALUES (@Name, @NIC, @Phone_No, @Address)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", NameBox.Text.Trim()),
                new SqlParameter("@NIC", NICBox.Text.Trim()),
                new SqlParameter("@Phone_No",
                    string.IsNullOrWhiteSpace(MobileBox.Text) ? (object)DBNull.Value : MobileBox.Text.Trim()),
                new SqlParameter("@Address", AddressBox.Text.Trim())
            };

            if (mainClass.InsertData(sql, "Customer saved successfully", "Failed to save customer", parameters))
            {
                LoadGrid();
                ClearFields();
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Customer_Id_PK"].Value);

            string sql = @"UPDATE Customer 
                           SET Name=@Name, NIC=@NIC, Phone_No=@Phone_No, Address=@Address 
                           WHERE Customer_Id_PK=@Id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", NameBox.Text.Trim()),
                new SqlParameter("@NIC", NICBox.Text.Trim()),
                new SqlParameter("@Phone_No",
                    string.IsNullOrWhiteSpace(MobileBox.Text) ? (object)DBNull.Value : MobileBox.Text.Trim()),
                new SqlParameter("@Address", AddressBox.Text.Trim()),
                new SqlParameter("@Id", id)
            };

            if (mainClass.UpdateData(sql, parameters))
            {
                LoadGrid();
                ClearFields();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Customer_Id_PK"].Value);

            string sql = "DELETE FROM Customer WHERE Customer_Id_PK=@Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            if (mainClass.DeleteData(sql, parameters))
            {
                LoadGrid();
                ClearFields();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            NameBox.Text = row.Cells["Name"].Value.ToString();
            NICBox.Text = row.Cells["NIC"].Value.ToString();
            MobileBox.Text = row.Cells["Phone_No"].Value.ToString();
            AddressBox.Text = row.Cells["Address"].Value.ToString();
        }
    }
}
